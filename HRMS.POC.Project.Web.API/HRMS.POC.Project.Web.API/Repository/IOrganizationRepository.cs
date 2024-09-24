using HRMS.POC.Project.Web.API.Models;
using HRMS.POC.Project.Web.API.Models.DTO;

namespace HRMS.POC.Project.Web.API.Repository
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetOrganizationsAsync();

        Task<Organization> GetOrganizationByIdAsync(Guid id);

        public Task<OrganizationDTO> AddOrganizationAsync(OrganizationDTO organizationDto);

        public Task<Organization> UpdateOrganizations(Organization organization);

        public Task<Organization> RemoveOrganizationAsync(Organization organization);

        public Task<string> GetOrganizationByName(string name);

        public Task<bool> AddUserToOrganization(string organizationId, ApplicationUser user);

        Task<Organization> FindOrganizationAsync();

        Task<string> GetOrganizationNameByUserIdAsync(string userId);



    }
}