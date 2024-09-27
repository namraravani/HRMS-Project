using HRMS_POC_Project_Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace HRMS_POC_Project_Frontend.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(IUserService userService,IAuthService authService,IHttpContextAccessor httpContextAccessor)  { 
            
            _authService = authService;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsersAsync();
            return View(users);
        }

        
        
    }
}
