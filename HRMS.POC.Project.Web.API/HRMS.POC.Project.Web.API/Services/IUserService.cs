using HRMS.POC.Project.Web.API.Models.Register;
using Microsoft.AspNetCore.Mvc;
using User.Management.API.Models.Login;

namespace HRMS.POC.Project.Web.API.Services
{
    public interface IUserService
    {
        public Task<string> Register([FromBody] RegisterUser registerUser);

        public Task<string> Login([FromBody] LoginUser loginModel);
    }
}
