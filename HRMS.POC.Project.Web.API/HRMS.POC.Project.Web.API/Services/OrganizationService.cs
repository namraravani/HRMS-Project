using HRMS.POC.Project.Web.API.Models;
using HRMS.POC.Project.Web.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.POC.Project.Web.API.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository) {

            _organizationRepository = organizationRepository;
        }

        public async Task<IEnumerable<Organization>> GetOrganizationAsync(string userId, string role) { 

            var result = await _organizationRepository.GetUserOrganizationsAsync(userId, role);

            return result;
        }
        public async Task<(bool Success, string Message)> AddOrgUserAsync(ApplicationUser user)
        {
            var orgExist = await _organizationRepository.FindOrganizationAsync();
            if (orgExist == null)
            {
                return (false, "Organization does not exist.");
            }

            
            var result = await _organizationRepository.AddUserToOrganization(orgExist.Id, user);

            if (result)
            {
                return (true, "User added to organization successfully.");
            }

            return (false, "Failed to add user to organization.");
        }

        public async Task<string> GetOrganizationIdByUserIdAsync(string userId)
        {
            return await _organizationRepository.GetOrganizationIdByUserIdAsync(userId);
        }


    }
}
