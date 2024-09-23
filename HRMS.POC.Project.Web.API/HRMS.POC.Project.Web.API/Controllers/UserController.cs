using HRMS.POC.Project.Web.API.Models.Register;
using HRMS.POC.Project.Web.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.POC.Project.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) { 
            _userRepository = userRepository;
        }


        
        [HttpGet]
        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return users;
        }

        [HttpPost]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) {
                
                return NotFound();
            }
            
            return Ok(user);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser user)
        {
            if (user == null || string.IsNullOrEmpty(user.Id) || user.Id != id)
            {
                return BadRequest("Invalid user data.");
            }

            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Created_by = user.Created_by; 

            var updatedUser = await _userRepository.UpdateUserAsync(existingUser);
            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var deletedUser = await _userRepository.DeleteUserAsync(user);
            if (deletedUser == null)
            {
                return NotFound();
            }

            return Ok(new { Message = "User deleted successfully!" });
        }


    }
}