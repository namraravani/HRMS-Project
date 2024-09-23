using HRMS.POC.Project.Web.API.Models;

namespace HRMS.POC.Project.Web.API.Repository
{
    public interface IUserRepository
    {
        
        public Task<IEnumerable<ApplicationUser>> GetUsersAsync();

        public Task<ApplicationUser> GetUserByIdAsync(string id);

        public Task<ApplicationUser> UpdateUserAsync(ApplicationUser user);

        public Task<ApplicationUser> DeleteUserAsync(ApplicationUser user);
    }
}
