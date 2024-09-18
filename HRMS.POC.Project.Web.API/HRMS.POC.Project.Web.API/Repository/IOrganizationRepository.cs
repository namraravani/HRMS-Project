using HRMS.POC.Project.Web.API.Models;

namespace HRMS.POC.Project.Web.API.Repository
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetOrganizationsAsync();

        Task<Organization> GetOrganizationByIdAsync(Guid id);

        public Task<Organization> AddOrganizationAsync(Organization organization);

        public Task<Organization> UpdateOrganizations(Organization organization);

        public Task<Organization> RemoveOrganizationAsync(Organization organization);

    }
}