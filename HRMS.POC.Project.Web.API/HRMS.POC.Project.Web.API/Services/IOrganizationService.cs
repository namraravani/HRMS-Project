using HRMS.POC.Project.Web.API.DTO;
using HRMS.POC.Project.Web.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.POC.Project.Web.API.Services
{
    public interface IOrganizationService
    {
        Task<(bool Success, string Message)> AddOrgUserAsync(ApplicationUser user,string orgId);

        Task<string> GetOrganizationIdByUserIdAsync(string userId);

        Task<IEnumerable<Organization>> GetOrganizationAsync(string userId,string role);

        Task<string> CreateOrganization(OrganizationDTO organization, UserDTO user, string createdUserId);

        Task<Organization> UpdateOrganizationAsync(OrganizationDTO organizationDto);

        Task<bool> DeleteOrganizationAsync(string id);

        Task<OrganizationDTO> GetOrganizationByIdAsync(string id);
    }

}
