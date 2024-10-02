using HRMS_POC_Project_Frontend.Models;

namespace HRMS_POC_Project_Frontend.Services
{
    public interface IOrganizationService
    {
        Task<List<OrganizationDTO>> GetOrganizationAsync();

        Task<OrganizationDTO> CreateOrganizationAsync(CreateOrganizationRequest request);

        Task<OrganizationDTO> UpdateOrganizationAsync(OrganizationDTO organizationDto);

        Task<bool> DeleteOrganizationAsync(string id);

        Task<OrganizationDTO> GetOrganizationByIdAsync(string id);
    }
}
