using HRMS_POC_Project_Frontend.Models;

namespace HRMS_POC_Project_Frontend.Services
{
    public interface IOrganizationService
    {
        Task<List<OrganizationDTO>> GetOrganizationAsync();

        public Task<OrganizationDTO> CreateOrganizationAsync(CreateOrganizationRequest request);

        public Task<OrganizationDTO> UpdateOrganizationAsync(OrganizationDTO organizationDto);

        public Task<bool> DeleteOrganizationAsync(string id);

        public Task<OrganizationDTO> GetOrganizationByIdAsync(string id);
    }
}
