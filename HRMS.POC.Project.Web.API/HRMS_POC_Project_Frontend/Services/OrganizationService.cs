using HRMS_POC_Project_Frontend.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HRMS_POC_Project_Frontend.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthTokenService _authTokenService;

        public OrganizationService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _authTokenService = new AuthTokenService(httpContextAccessor);
            _authTokenService.SetAuthTokenInHeader(_httpClient);
        }

        public async Task<List<OrganizationDTO>> GetOrganizationAsync()
        {
            
            _authTokenService.SetAuthTokenInHeader(_httpClient);
            var result = await _httpClient.GetFromJsonAsync<List<OrganizationDTO>>("api/Organization");
            return result;
        }

        public async Task<OrganizationDTO> CreateOrganizationAsync(CreateOrganizationRequest request)
        {
            _authTokenService.SetAuthTokenInHeader(_httpClient);
            var response = await _httpClient.PostAsJsonAsync("api/Organization", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<OrganizationDTO>();
            }

            return null; 
        }

        public async Task<OrganizationDTO> UpdateOrganizationAsync(OrganizationDTO organizationDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Organization/{organizationDto.Id}", organizationDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OrganizationDTO>();
        }

        public async Task<bool> DeleteOrganizationAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/Organization/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<OrganizationDTO> GetOrganizationByIdAsync(string id)
        {
            _authTokenService.SetAuthTokenInHeader(_httpClient);
            var response = await _httpClient.GetAsync($"api/Organization/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content); 

                try
                {
                    return JsonSerializer.Deserialize<OrganizationDTO>(content, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true 
                    });
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Deserialization error: {ex.Message}");
                    return null; 
                }
            }

            
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {errorContent}");
            return null;
        }





    }
}
