using Dapper;
using HRMS.POC.Project.Web.API.Models.Register;
using HRMS.POC.Project.Web.API.Repository;
using HRMS.POC.Project.Web.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using User.Management.API.Models.Login;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly string _jwtSecret;
    private readonly IOrganizationService _organizationService;

    public UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager, string jwtSecret,IOrganizationService organizationService)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _jwtSecret = jwtSecret;
        _organizationService = organizationService;
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

        
        var orgUserResult = await _organizationService.AddOrgUserAsync(newUser);
        if (!orgUserResult.Success) 
        {
            return "Failed to add user to organization: " + orgUserResult.Message;
        }

        await _userRepository.UpdateUserAsync(newUser);

        return newUser.Id;
    }



    public async Task<string> Login(LoginUser userDto)
    {
        var user = await _userManager.FindByNameAsync(userDto.Username);
        if (user == null) return null;

        var passwordCheck = await _userManager.CheckPasswordAsync(user, userDto.Password);
        if (!passwordCheck) return null;

        
        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
        var organizationName = await _organizationService.GetOrganizationNameByUserIdAsync(user.Id); 

       
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, role),
            new Claim("OrganizationName", organizationName)
        }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

}
