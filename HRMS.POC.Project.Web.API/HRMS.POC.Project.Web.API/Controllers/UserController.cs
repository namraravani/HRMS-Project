using HRMS.POC.Project.Web.API.Models.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.POC.Project.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public List<string> CreateUser([FromBody] RegisterUser registerUser)
        {
            return ["Namra", "parthiv", "Abhi"];
        }
    }
}
