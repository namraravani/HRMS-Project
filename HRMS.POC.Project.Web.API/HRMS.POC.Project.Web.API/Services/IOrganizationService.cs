using HRMS.POC.Project.Web.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.POC.Project.Web.API.Services
{
    public interface IOrganizationService
    {
        public Task<(bool Success, string Message)> AddOrgUserAsync(ApplicationUser user);

        public Task<string> GetOrganizationIdByUserIdAsync(string userId);

        public Task<IEnumerable<Organization>> GetOrganizationAsync(string userId, string role);
    }
}
