using HRMS.POC.Project.Web.API.DTO;
using HRMS.POC.Project.Web.API.Models;
using Microsoft.AspNetCore.Identity;

namespace HRMS.POC.Project.Web.API.Repository
{
    public interface IUserRepository
    {
        
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();

        Task<ApplicationUser> GetUserByIdAsync(string id);

        Task<bool> UpdateUserAsync(ApplicationUser user);

        Task<ApplicationUser> DeleteUserAsync(ApplicationUser user);

        Task<ApplicationUser> GetUserByUsername(string username);

        Task<string> AddUser(ApplicationUser user, string password, UserManager<ApplicationUser> userManager);

        Task<IEnumerable<UserDTO>> GetUsersByOrganizationIdAsync(string organizationId);

        Task<bool> DeleteUserForOrganizationAsync(string userId);

        Task<string> AddUserAsync(UserDTO userDto, string creatorUserId, string organizationId, string assignedRole);
    }
}
