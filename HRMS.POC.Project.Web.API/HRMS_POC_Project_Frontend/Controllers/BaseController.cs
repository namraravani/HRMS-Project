    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;

    public class BaseController : Controller
    {
        protected string GetAuthToken()
        {
            // Retrieve the token from cookies
            return HttpContext.Request.Cookies["AuthToken"];
        }

        protected void SetAuthTokenInHeader(HttpClient client)
        {
            var token = GetAuthToken();
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
