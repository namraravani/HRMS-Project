namespace HRMS_POC_Project_Frontend.Services
{
    public interface IAuthService
    {
        Task<string> GetProtectedDataAsync();
    }
}
