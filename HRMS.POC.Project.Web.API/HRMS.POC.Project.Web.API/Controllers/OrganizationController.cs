using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMS.POC.Project.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRMS.POC.Project.Web.API.Repository;
using HRMS.POC.Project.Web.API.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using HRMS.POC.Project.Web.API.Services;

namespace HRMS.POC.Project.Web.API.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class OrganizationController : BaseController
    {
        private readonly HrmsDbContext _context;
        private readonly IOrganizationService _organizationService;

        public OrganizationController(HrmsDbContext context, IOrganizationService organizationService)
        {
            _context = context;
            _organizationService = organizationService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizations()
        {
            
            var userId = UserId;
            var userRole = UserRole;
            

            var result = await _organizationService.GetOrganizationAsync(userId,userRole);
            return Ok(result);
        }


        //[HttpGet("{id}")]
        //public async Task<ActionResult<Organization>> GetOrganization(Guid id)
        //{
        //    var result = await _organizationRepository.GetOrganizationByIdAsync(id);


        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<OrganizationDTO>> CreateOrganization([FromBody] CreateOrganizationRequest request)
        {
            var createdOrganization = await _organizationService.CreateOrganization(request.Organization, request.User, UserId);

            if (createdOrganization == null)
            {
                return BadRequest();
            }

            return Ok(createdOrganization); // Or return CreatedAtAction if desired
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganization(string id, OrganizationDTO organizationDto)
        {
            if (id != organizationDto.Id)
            {
                return BadRequest("Organization ID mismatch.");
            }

            var updatedOrganization = await _organizationService.UpdateOrganizationAsync(organizationDto);

            if (updatedOrganization == null)
            {
                return NotFound("Organization not found.");
            }

            return Ok(updatedOrganization);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(string id)
        {
            var result = await _organizationService.DeleteOrganizationAsync(id);

            if (!result)
            {
                return NotFound("Organization not found.");
            }

            return NoContent(); // 204 No Content
        }

        private bool OrganizationExists(string id)
        {
            return _context.Organizations.Any(e => e.Id == id);
        }

    }
}