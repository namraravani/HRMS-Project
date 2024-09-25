using HRMS.POC.Project.Web.API.Models;
using HRMS.POC.Project.Web.API.Models.DTO;
using HRMS.POC.Project.Web.API.Models.Register;
using HRMS.POC.Project.Web.API.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.POC.Project.Web.API.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public OrganizationService(IOrganizationRepository organizationRepository,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _organizationRepository = organizationRepository;
            
        }

        public async Task<OrganizationDTO> CreateOrganization(OrganizationDTO organization, UserDTO user, string createdUserId)
        {
            var result1 = await _organizationRepository.AddOrganizationAsync(organization);
            if (result1 == null)
            {
                return null;
            }

            // Create A Admin for that organization
            var firstUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                firstName = user.FirstName,
                lastName = user.LastName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Is_Delete = false

            };

            var result = await _userManager.CreateAsync(firstUser, user.Password);
            if (!result.Succeeded)
            {
                return null;
            }

            firstUser.Created_by = createdUserId;

            if (!await _userManager.IsInRoleAsync(firstUser, "Admin"))
            {
                await _userManager.AddToRoleAsync(firstUser, "Admin");
            }

            var orgUserResult = await AddOrgUserAsync(firstUser);

            return result1;

        }

        public async Task<IEnumerable<Organization>> GetOrganizationAsync(string userId, string role) {

            
            var result = await _organizationRepository.GetUserOrganizationsAsync(userId,role);

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

        public async Task<Organization> UpdateOrganizationAsync(OrganizationDTO organizationDto)
        {
            
            var organization = new Organization
            {
                Id = organizationDto.Id,
                orgName = organizationDto.orgName,
                address = organizationDto.address
            };

            return await _organizationRepository.UpdateOrganizationAsync(organization);
        }

        public async Task<bool> DeleteOrganizationAsync(string id)
        {
            
            return await _organizationRepository.DeleteOrganizationAsync(id);
        }


    }
}
