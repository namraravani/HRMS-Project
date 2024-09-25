using HRMS.POC.Project.Web.API.Models.Configuration;
using HRMS.POC.Project.Web.API.Models.DTO;
using HRMS.POC.Project.Web.API.Models.Register;
using HRMS.POC.Project.Web.API.Repository;
using HRMS.POC.Project.Web.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.POC.Project.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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


        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            ValidateUser();
            var Organizationid = OrganizationId;
            var users = await _userService.GetUsersByOrganizationIdAsync(Organizationid);
            return users;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO user, string assignedRole)
        {
            
            var result = await _userService.ValidateUserForAdd(UserRole, user, UserId, OrganizationId, assignedRole);

            if(result == "Unauthorized")
            {
                return BadRequest(result);  
            }
            else if(result == "Failed to create user.")
            {
                return BadRequest(result);
            }
            
            return Ok(result); 
        }



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

        //// PUT: api/user/update/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto userDto)
        //{
        //    if (userDto == null)
        //    {
        //        return BadRequest("Invalid user data.");
        //    }

        //    var existingUser = await _userRepository.GetUserByIdAsync(id);
        //    if (existingUser == null)
        //    {
        //        return NotFound();
        //    }

        //    // Only update the fields that are provided in the DTO
        //    existingUser.UserName = userDto.UserName ?? existingUser.UserName;
        //    existingUser.firstName = userDto.FirstName ?? existingUser.firstName;
        //    existingUser.lastName = userDto.LastName ?? existingUser.lastName;

        //    var updatedUser = await _userRepository.UpdateUserAsync(existingUser);
        //    if (updatedUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(updatedUser);
        //}



        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser user)
        //{
        //    if (user == null || string.IsNullOrEmpty(user.Id) || user.Id != id)
        //    {
        //        return BadRequest("Invalid user data.");
        //    }

        //    var existingUser = await _userRepository.GetUserByIdAsync(id);
        //    if (existingUser == null)
        //    {
        //        return NotFound();
        //    }


        //    existingUser.UserName = user.UserName;
        //    existingUser.Email = user.Email;
        //    existingUser.PhoneNumber = user.PhoneNumber;
        //    existingUser.Created_by = user.Created_by; 

        //    var updatedUser = await _userRepository.UpdateUserAsync(existingUser);
        //    if (updatedUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(updatedUser);
        //}



        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(string id)
        //{
        //    var user = await _userRepository.GetUserByIdAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var deletedUser = await _userRepository.DeleteUserAsync(user);
        //    if (deletedUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(new { Message = "User deleted successfully!" });
        //}


    }
}