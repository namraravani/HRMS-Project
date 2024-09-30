using HRMS.POC.Project.Web.API.Models;
using HRMS.POC.Project.Web.API.Models.DTO;

namespace HRMS.POC.Project.Web.API.Repository
{
    public interface IOrganizationRepository
    {
        public Task<IEnumerable<Organization>> GetUserOrganizationsAsync(string userId, string role);

        Task<Organization> GetOrganizationByIdAsync(Guid id);

        public Task<string> AddOrganizationAsync(OrganizationDTO organizationDto);

        public Task<Organization> UpdateOrganizationAsync(Organization organization);

        public Task<bool> DeleteOrganizationAsync(string id);

        public Task<string> GetOrganizationByName(string name);

        public Task<bool> AddUserToOrganization(string organizationId, ApplicationUser user);

        Task<Organization> FindOrganizationAsync(string orgId);

        Task<string> GetOrganizationIdByUserIdAsync(string userId);

        public Task<IEnumerable<string>> FetchUsersFromOrganizationIdAsync(string organizationId);

        Task<OrganizationDTO> GetOrganizationByIdAsync(string id);





    }
}