using Microsoft.AspNetCore.Mvc;

namespace HRMS.POC.Project.Web.API.Services
{
    public interface IOrganizationService
    {
        public Task<(bool Success, string Message)> AddOrgUserAsync(ApplicationUser user);

        public Task<string> GetOrganizationNameByUserIdAsync(string userId);
    }
}
