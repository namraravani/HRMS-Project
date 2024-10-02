using HRMS.POC.Project.Web.API.DTO;
using HRMS.POC.Project.Web.API.Models.Configuration;
using HRMS.POC.Project.Web.API.Models.Register;
using HRMS.POC.Project.Web.API.Repository;
using HRMS.POC.Project.Web.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.Management.API.Models.Login;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly string _jwtSecret;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IOrganizationService _organizationService;

    public UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager, IOptions<JwtSettings> jwtSettings, IOrganizationService organizationService, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _jwtSecret = jwtSettings.Value.Secret;
        _roleManager = roleManager;
        _organizationService = organizationService;
        _configuration = configuration;
    }

    public async Task<string> Register(RegisterUser registerUser)
    {
        var existingUser = await _userRepository.GetUserByUsername(registerUser.Username);
        if (existingUser != null) return "0";

        var newUser = new ApplicationUser
        {
            UserName = registerUser.Username,
            Email = registerUser.Email,
            PhoneNumber = registerUser.PhoneNumber,
            firstName = registerUser.firstName,
            lastName = registerUser.lastName,
            SecurityStamp = Guid.NewGuid().ToString(),
            Is_Delete = false
        };

        var result = await _userManager.CreateAsync(newUser, registerUser.Password);
        if (!result.Succeeded)
        {
            return "User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description));
        }

        if (!await _userManager.IsInRoleAsync(newUser, "Admin"))
        {
            await _userManager.AddToRoleAsync(newUser, "Admin");
        }

        newUser.Created_by = newUser.Id;


        

        await _userRepository.UpdateUserAsync(newUser);

        return newUser.Id;
    }
    public async Task<string> Login(LoginUser userDto)
    {
        var user = await _userManager.FindByNameAsync(userDto.Username);
        

        var passwordCheck = await _userManager.CheckPasswordAsync(user, userDto.Password);
        

        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
        

        var organizationId = await _organizationService.GetOrganizationIdByUserIdAsync(user.Id);
        

        if (user == null || passwordCheck == null || role == null || organizationId == null)
        {
            return "User can't login successfully";
        }


        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, role),
            new Claim("OrganizationId", organizationId),
            new Claim("UserId", user.Id)
        }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = _configuration["JWT:ValidAudience"],
            Issuer = _configuration["JWT:ValidIssuer"]
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }



    public async Task<IEnumerable<UserDTO>> GetUsersByOrganizationIdAsync(string organizationId)
    {
        return await _userRepository.GetUsersByOrganizationIdAsync(organizationId);
    }

    public async Task<string> ValidateUserForAdd(string role, UserDTO user, string creatorUserId, string organizationId, string assignedRole)
    {
        if (role == "Employee")
        {
            return "Unauthorized"; 
        }

        var newUserId = await _userRepository.AddUserAsync(user, creatorUserId, organizationId, assignedRole);

        if (newUserId == null)
        {
            return "Failed to create user.";
        }

        return newUserId;
    }

    public async Task<ApplicationUser> CheckUserForUpdate(string userId, string accessorId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null)
        {
            return null;
        }

       
        return user.Created_by == accessorId ? user : null;
    }

    public async Task<bool> UpdateUser(ApplicationUser user)
    {
        return await _userRepository.UpdateUserAsync(user);
    }

    public async Task<ApplicationUser> GetUserByIdAsync(string id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<bool> DeleteUserAsync(string id)
    {
        var user = await GetUserByIdAsync(id);
        if (user == null)
        {
            return false; 
        }

        var deletedUser = await _userRepository.DeleteUserAsync(user);
        return deletedUser != null; 
    }












}
