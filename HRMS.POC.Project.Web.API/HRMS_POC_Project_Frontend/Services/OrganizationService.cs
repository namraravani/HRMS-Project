using HRMS_POC_Project_Frontend.Models;

namespace HRMS_POC_Project_Frontend.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly HttpClient _httpClient;

        public OrganizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OrganizationDTO>> GetOrganizationAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<OrganizationDTO>>("api/Organization");
            return result;
        }



    }
}
