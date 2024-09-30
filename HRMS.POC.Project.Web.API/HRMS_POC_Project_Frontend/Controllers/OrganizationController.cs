using HRMS_POC_Project_Frontend.Models;
using HRMS_POC_Project_Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMS_POC_Project_Frontend.Controllers
{
    public class OrganizationController : BaseController
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        
        public async Task<IActionResult> Index()
        {
            var organizations = await _organizationService.GetOrganizationAsync();
            return View(organizations);
        }

       
        public IActionResult Create()
        {
            return View(new CreateOrganizationRequest());
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrganizationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _organizationService.CreateOrganizationAsync(request);
            if (result == null)
            {
                ModelState.AddModelError("", "Failed to create organization.");
                return View(request);
            }

            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Edit(string id)
        {
            var organization = await _organizationService.GetOrganizationByIdAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            var request = new CreateOrganizationRequest
            {
                Organization = organization,
                User = new UserDTO()
            };

            return View(request);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(CreateOrganizationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _organizationService.UpdateOrganizationAsync(request.Organization);
            if (result == null)
            {
                ModelState.AddModelError("", "Failed to update organization.");
                return View(request);
            }

            return RedirectToAction("Index");
        }

       
        public async Task<IActionResult> Delete(string id)
        {
            var organization = await _organizationService.GetOrganizationByIdAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _organizationService.DeleteOrganizationAsync(id);
            if (!result)
            {
                ModelState.AddModelError("", "Failed to delete organization.");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
