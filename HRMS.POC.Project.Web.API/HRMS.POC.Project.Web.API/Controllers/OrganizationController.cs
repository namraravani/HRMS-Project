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
            ValidateUser();
            var userId = UserId;
            var userRole = UserRole;
            var organizationId = OrganizationId;

            var result = await _organizationService.GetOrganizationAsync(userId, UserRole);
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


        //[HttpPost]
        //public async Task<ActionResult<OrganizationDTO>> CreateOrganization(OrganizationDTO organization)
        //{
        //    var createdOrganization = await _organizationRepository.AddOrganizationAsync(organization);

        //    return CreatedAtAction(nameof(GetOrganization), new { id = createdOrganization.Id }, createdOrganization);
        //}


        //// PUT: api/Organization/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateOrganization(string id, Organization organization)
        //{
        //    if (id != organization.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await _organizationRepository.UpdateOrganizations(organization);

        //    return Ok(organization);
        //}



        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrganization(Guid id)
        //{
        //    var organization = await _organizationRepository.GetOrganizationByIdAsync(id);
        //    if (organization == null)
        //    {
        //        return NotFound();
        //    }

            
        //    await _organizationRepository.RemoveOrganizationAsync(organization);

        //    return Ok();
        //}

        private bool OrganizationExists(string id)
        {
            return _context.Organizations.Any(e => e.Id == id);
        }

    }
}