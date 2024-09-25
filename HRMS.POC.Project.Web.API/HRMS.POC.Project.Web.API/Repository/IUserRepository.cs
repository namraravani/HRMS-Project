using HRMS.POC.Project.Web.API.Models;
using HRMS.POC.Project.Web.API.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace HRMS.POC.Project.Web.API.Repository
{
    public interface IUserRepository
    {
        
        public Task<IEnumerable<ApplicationUser>> GetUsersAsync();

        public Task<ApplicationUser> GetUserByIdAsync(string id);

        public Task<ApplicationUser> UpdateUserAsync(ApplicationUser user);

        public Task<ApplicationUser> DeleteUserAsync(ApplicationUser user);

        public Task<ApplicationUser> GetUserByUsername(string username);

        public Task<string> AddUser(ApplicationUser user, string password, UserManager<ApplicationUser> userManager);

        public Task<IEnumerable<UserDTO>> GetUsersByOrganizationIdAsync(string organizationId);

        public Task<string> AddUserAsync(UserDTO userDto, string creatorUserId, string organizationId, string assignedRole);
    }
}
