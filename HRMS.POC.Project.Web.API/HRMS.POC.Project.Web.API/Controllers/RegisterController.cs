using HRMS.POC.Project.Web.API.Models;
using HRMS.POC.Project.Web.API.Models.Register;
using HRMS.POC.Project.Web.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.Management.API.Models.Login;

namespace HRMS.POC.Project.Web.API.Controllers
{
    [ApiController]
    [Route("api/Register")]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HrmsDbContext _dbContext;
        private readonly IUserService _userService;

        private readonly IConfiguration _configuration;

        public RegisterController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, HrmsDbContext dbContext,IUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _dbContext = dbContext;
            _userService = userService;
            
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegisterUser userDto)
        {
            var result = await _userService.Register(userDto);
            if (result == "0")
            {
                return BadRequest("hello there is an error");
            }
            if (result == null) return BadRequest("user already exists.");
            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser userDto)
        {
            var token = await _userService.Login(userDto);
            if (token == null) return Unauthorized();
            return Ok(new { Token = token });
        }

        //[HttpPost]
        //public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string? role)
        //{
        //    var user1 = new ApplicationUser
        //    {
        //        firstName = registerUser.firstName,
        //        lastName = registerUser.lastName,
        //        Email = registerUser.Email,
        //        PhoneNumber = registerUser.PhoneNumber,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = registerUser.Username,
        //        Created_by = null,
        //        Is_Delete = false 
        //    };

        //    var result1 = await _userManager.CreateAsync(user1, registerUser.Password);
        //    if (result1.Succeeded)
        //    {
        //        if (!string.IsNullOrEmpty(role))
        //        {
        //            await _userManager.AddToRoleAsync(user1, role);
        //        }
        //        else
        //        {
        //            await _userManager.AddToRoleAsync(user1, "Employee"); 
        //        }

        //        return Ok(new { Message = "Employee registered successfully!" });
        //    }

        //    return BadRequest(result1.Errors);
        //}


        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> Login([FromBody] LoginUser loginModel)
        //{
        //    var user = await _userManager.FindByNameAsync(loginModel.Username);

        //    if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
        //    {
        //        var authClaims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,user.UserName),
        //            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        //        };

        //        var userRoles = await _userManager.GetRolesAsync(user);
        //        foreach (var role in userRoles)
        //        {
        //            authClaims.Add(new Claim(ClaimTypes.Role, role));
        //        }

        //        var jwtToken = GetToken(authClaims);

        //        return Ok(new
        //        {
        //            token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
        //            expiration = jwtToken.ValidTo
        //        });
        //    }

        //    return Unauthorized();
        //}

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }




    }
}
