using HRMS.POC.Project.Web.API.DTO;
using HRMS.POC.Project.Web.API.Models.Register;
using Microsoft.AspNetCore.Mvc;
using User.Management.API.Models.Login;

namespace HRMS.POC.Project.Web.API.Services
{
    public interface IUserService
    {
        Task<string> Register([FromBody] RegisterUser registerUser);

        Task<string> Login([FromBody] LoginUser loginModel);

        Task<IEnumerable<UserDTO>> GetUsersByOrganizationIdAsync(string organizationId);

        Task<ApplicationUser> CheckUserForUpdate(string userId, string accessorId);

        Task<bool> UpdateUser(ApplicationUser user);

        Task<string> ValidateUserForAdd(string role, UserDTO user, string creatorUserId, string organizationId, string assignedRole);

        Task<ApplicationUser> GetUserByIdAsync(string id);

        Task<bool> DeleteUserAsync(string id);
    }
}
