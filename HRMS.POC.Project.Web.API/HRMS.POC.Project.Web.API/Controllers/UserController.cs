using HRMS.POC.Project.Web.API.Models.Configuration;
using HRMS.POC.Project.Web.API.Models.DTO;
using HRMS.POC.Project.Web.API.Models.Register;
using HRMS.POC.Project.Web.API.Repository;
using HRMS.POC.Project.Web.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRMS.POC.Project.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        

        public UserController(IUserService userService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            
        }


        [Authorize(Policy = "GetUsersPolicy")]
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            ValidateUser();
            var Organizationid = OrganizationId;
            var users = await _userService.GetUsersByOrganizationIdAsync(Organizationid);
            return users;
        }

        [Authorize(Policy = "CreateUsersPolicy")]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO user, string assignedRole)
        {

            var result = await _userService.ValidateUserForAdd(UserRole, user, UserId, OrganizationId, assignedRole);

            if (result == "Unauthorized")
            {
                return BadRequest(result);
            }
            else if (result == "Failed to create user.")
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> GetUserById(string id)
        //{
        //    var user = await _userRepository.GetUserByIdAsync(id);
        //    if (user == null) {

        //        return NotFound();
        //    }

        //    return Ok(user);
        //}

        //[HttpPost("create")]
        //public async Task<IActionResult> UserCreateAsync([FromBody] RegisterUser registerUser, string role)
        //{
        //    if (registerUser == null || string.IsNullOrEmpty(registerUser.Username) || string.IsNullOrEmpty(registerUser.Password))
        //    {
        //        return BadRequest("Invalid user data.");
        //    }

        //    var user = new ApplicationUser
        //    {
        //        Email = registerUser.Email,
        //        UserName = registerUser.Username,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        Created_by = GlobalConstants.CreatedBy, 
        //        firstName = registerUser.firstName, 
        //        lastName = registerUser.lastName
        //    };

        //    if (await _roleManager.RoleExistsAsync(role))
        //    {
        //        var result = await _userManager.CreateAsync(user, registerUser.Password);
        //        if (!result.Succeeded)
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User Failed To Create" });
        //        }
        //        await _userManager.AddToRoleAsync(user, role);
        //        return Ok(new { Message = "User created successfully!" });
        //    }

        //    return BadRequest("Role does not exist.");
        //}


        [Authorize(Policy = "UpdateUsersPolicy")]
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null)
            {
                return BadRequest("Invalid user data.");
            }

            var accessorId = UserId;
            var roleId = UserRole; 

            
            var existingUser = await _userService.CheckUserForUpdate(id, accessorId);
            if (existingUser == null)
            {
                return NotFound("User not found or not authorized to update.");
            }

            
            if (roleId == "HR" && existingUser.Created_by != accessorId)
            {
                return Forbid(); 
            }
            else if (roleId != "Admin")
            {
                return Forbid(); 
            }

            
            existingUser.UserName = updateUserDto.UserName ?? existingUser.UserName;
            existingUser.firstName = updateUserDto.FirstName ?? existingUser.firstName;
            existingUser.lastName = updateUserDto.LastName ?? existingUser.lastName;

            
            var updateSuccess = await _userService.UpdateUser(existingUser);
            if (!updateSuccess)
            {
                return StatusCode(500, "Failed to update user.");
            }

            return Ok("User updated successfully.");
        }

        [Authorize(Policy = "DeleteUsersPolicy")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            
            var deleteSuccess = await _userService.DeleteUserAsync(id);
            if (!deleteSuccess)
            {
                return NotFound("User not found or could not be deleted.");
            }

            return Ok(new { Message = "User deleted successfully!" });
        }



    }
}