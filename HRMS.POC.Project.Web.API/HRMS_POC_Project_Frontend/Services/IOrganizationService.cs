using HRMS_POC_Project_Frontend.Models;

namespace HRMS_POC_Project_Frontend.Services
{
    public interface IOrganizationService
    {
        Task<List<OrganizationDTO>> GetOrganizationAsync();
    }
}
