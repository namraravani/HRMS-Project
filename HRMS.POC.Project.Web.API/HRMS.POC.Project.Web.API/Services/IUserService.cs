using HRMS.POC.Project.Web.API.Models.DTO;
using HRMS.POC.Project.Web.API.Models.Register;
using Microsoft.AspNetCore.Mvc;
using User.Management.API.Models.Login;

namespace HRMS.POC.Project.Web.API.Services
{
    public interface IUserService
    {
        public Task<string> Register([FromBody] RegisterUser registerUser);

        public Task<string> Login([FromBody] LoginUser loginModel);

        public Task<IEnumerable<UserDTO>> GetUsersByOrganizationIdAsync(string organizationId);

        public Task<ApplicationUser> CheckUserForUpdate(string userId, string accessorId);

        public Task<bool> UpdateUser(ApplicationUser user);

        public Task<string> ValidateUserForAdd(string role, UserDTO user, string creatorUserId, string organizationId, string assignedRole);

        public Task<ApplicationUser> GetUserByIdAsync(string id);

        public Task<bool> DeleteUserAsync(string id);
    }
}
