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

        public async Task<string> CreateOrganization(OrganizationDTO organizationDto, UserDTO userDto, string createdUserId)
        {
            // Step 1: Add the organization
            var organizationId = await _organizationRepository.AddOrganizationAsync(organizationDto);
            if (string.IsNullOrEmpty(organizationId))
            {
                return null; // Return or handle the error
            }

            // Step 2: Create the user
            var newUser = new ApplicationUser
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                firstName = userDto.FirstName,
                lastName = userDto.LastName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Is_Delete = false,
                Created_by = createdUserId // Set created by before user creation
            };

            var createUserResult = await _userManager.CreateAsync(newUser, userDto.Password);
            if (!createUserResult.Succeeded)
            {
                // Log errors or handle them accordingly
                return null;
            }

            // Step 3: Assign role if not already assigned
            if (!await _userManager.IsInRoleAsync(newUser, "Admin"))
            {
                await _userManager.AddToRoleAsync(newUser, "Admin");
            }

            // Step 4: Add the user to the organization
            var addOrgUserResult = await AddOrgUserAsync(newUser, organizationId);
            if (!addOrgUserResult.Success)
            {
                // Handle failure to add user to organization
                return null;
            }

            return organizationId; // Return the ID of the newly created organization
        }

        public async Task<IEnumerable<Organization>> GetOrganizationAsync(string userId, string role) {

            
            var result = await _organizationRepository.GetUserOrganizationsAsync(userId,role);

            return result;
        }
        public async Task<(bool Success, string Message)> AddOrgUserAsync(ApplicationUser user, string orgId)
        {
            var orgExist = await _organizationRepository.FindOrganizationAsync(orgId);
            if (orgExist == null)
            {
                return (false, "Organization does not exist.");
            }

            // Ensure that the user is linked to the organization correctly
            var result = await _organizationRepository.AddUserToOrganization(orgExist.Id, user);

            return result ? (true, "User added to organization successfully.") : (false, "Failed to add user to organization.");
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
