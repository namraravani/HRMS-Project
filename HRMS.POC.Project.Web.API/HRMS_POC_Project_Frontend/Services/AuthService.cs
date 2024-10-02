using System.Net.Http.Headers;

namespace HRMS_POC_Project_Frontend.Services
{
    public class AuthService :IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;

            
            var token = httpContextAccessor.HttpContext?.Request.Cookies["AuthToken"];
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        
        public async Task<string> GetProtectedDataAsync()
        {
            var response = await _httpClient.GetAsync("api/protected-data");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
