using HRMS_POC_Project_Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_POC_Project_Frontend.Controllers
{

    
    public class OrganizationController : BaseController
    {
        private readonly IOrganizationService _organizationService;
        
        public OrganizationController(IOrganizationService organizationService)         {

            _organizationService = organizationService;
            
        }


        public async Task<IActionResult> Index()
        {
            var organizations = await _organizationService.GetOrganizationAsync();
            return View(organizations);
        }
    }
}
