using HRMS.POC.Project.Web.API.DTO;
using HRMS.POC.Project.Web.API.Models;

namespace HRMS.POC.Project.Web.API.Repository
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetUserOrganizationsAsync(string userId, string role);

        Task<Organization> GetOrganizationByIdAsync(Guid id);

        Task<string> AddOrganizationAsync(OrganizationDTO organizationDto);

        Task<Organization> UpdateOrganizationAsync(Organization organization);

        Task<bool> DeleteOrganizationAsync(string id);

        Task<string> GetOrganizationByName(string name);

        Task<bool> AddUserToOrganization(string organizationId, ApplicationUser user);

        Task<Organization> FindOrganizationAsync(string orgId);

        Task<string> GetOrganizationIdByUserIdAsync(string userId);

        Task<IEnumerable<string>> FetchUsersFromOrganizationIdAsync(string organizationId);

        Task<OrganizationDTO> GetOrganizationByIdAsync(string id);
    }
}