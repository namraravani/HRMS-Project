using HRMS_POC_Project_Frontend.Models;

namespace HRMS_POC_Project_Frontend.Services
{
    public interface IUserService
    {
        Task<List<string>> GetUsersAsync();

        Task<string> LoginAsync(LoginDTO loginDto);

        public Task<string> GetProtectedDataAsync(HttpClient client);
    }
}
