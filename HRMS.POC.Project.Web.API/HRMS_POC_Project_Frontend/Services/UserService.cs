using HRMS_POC_Project_Frontend.Models;
using System.Net.Http;

namespace HRMS_POC_Project_Frontend.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<string>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<string>>("api/users");
        }

        public async Task<string> LoginAsync(LoginDTO loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", loginDto);

            if (response.IsSuccessStatusCode)
            {
              
                var token = await response.Content.ReadAsStringAsync();
                return token; 
            }

            return null; 
        }

        public async Task<string> GetProtectedDataAsync(HttpClient client)
        {
            var response = await client.GetAsync("api/protected-data");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }
}
