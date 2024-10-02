using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HRMS_POC_Project_Frontend.Services
{
    public class AuthTokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthTokenService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetAuthToken()
        {
            
            var tokenJson = _httpContextAccessor.HttpContext?.Request.Cookies["AuthToken"];

            if (!string.IsNullOrEmpty(tokenJson))
            {
                using (JsonDocument doc = JsonDocument.Parse(tokenJson))
                {
                    if (doc.RootElement.TryGetProperty("token", out JsonElement tokenElement))
                    {
                        return tokenElement.GetString();
                    }
                }
            }

            return null;
        }

        public void SetAuthTokenInHeader(HttpClient httpClient)
        {
            var token = GetAuthToken();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
