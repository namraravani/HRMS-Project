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
        private readonly IUserRepository _userRepository;

        public OrganizationService(IOrganizationRepository organizationRepository,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,IUserRepository userRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
            
        }

        public async Task<string> CreateOrganization(OrganizationDTO organizationDto, UserDTO userDto, string createdUserId)
        {
            
            var organizationId = await _organizationRepository.AddOrganizationAsync(organizationDto);
            if (string.IsNullOrEmpty(organizationId))
            {
                return null;
            }

           
            var newUser = new ApplicationUser
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                firstName = userDto.FirstName,
                lastName = userDto.LastName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Is_Delete = false,
                Created_by = createdUserId 
            };

            var createUserResult = await _userManager.CreateAsync(newUser, userDto.Password);
            if (!createUserResult.Succeeded)
            {
                
                return null;
            }

            
            if (!await _userManager.IsInRoleAsync(newUser, "Admin"))
            {
                await _userManager.AddToRoleAsync(newUser, "Admin");
            }

            
            var addOrgUserResult = await AddOrgUserAsync(newUser, organizationId);
            if (!addOrgUserResult.Success)
            {
               
                return null;
            }

            return organizationId; 
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
            
            var userIds = await _organizationRepository.FetchUsersFromOrganizationIdAsync(id);
            bool allDeleted = true;

            
            foreach (var userId in userIds)
            {
                var userDeleted = await _userRepository.DeleteUserForOrganizationAsync(userId);
                if (userDeleted == null) 
                {
                    allDeleted = false;
                }
            }

            return allDeleted;
        }




    }
}
