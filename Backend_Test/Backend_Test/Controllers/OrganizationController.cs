using System;
using Backend_Test.Models;
using Backend_Test.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Test.Controllers
{
    [Route("api/organization")]
    [ApiController]

    public class OrganizationController : Controller
    {
        private OrganizationRepository _organizationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrganizationController(OrganizationRepository organizationRepository, IHttpContextAccessor httpContextAccessor)
        {
            _organizationRepository = organizationRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("all")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Organization>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAll()
        {
            Console.WriteLine(_httpContextAccessor.HttpContext.Request.Cookies[".AspNetCore.Cookies"]);
            var organizations = await _organizationRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(organizations);
        }

        [HttpGet("{BusinessRegistrationNumber}")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(Organization))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetById(int BusinessRegistrationNumber)
        {
            var user = await _organizationRepository.GetById(BusinessRegistrationNumber);
            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateOrganization(Organization organization)
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var primary_sid = identity.FindFirst(ClaimTypes.PrimarySid);
                var name = identity.FindFirst(ClaimTypes.Name);
                Console.WriteLine(primary_sid.Value);
                Console.WriteLine(name.Value);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rowsAffected = await _organizationRepository.CreateOrganization(organization);

            if (rowsAffected > 0)
                return Ok(new { message = "Organization created" });
            else
                return BadRequest("something went wrong");
        }

        [HttpPatch("{BusinessRegistrationNumber}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateOrganization(int BusinessRegistrationNumber, Organization organization)
        {
            var rowsAffected = await _organizationRepository.UpdateOrganization(BusinessRegistrationNumber, organization);

            if (rowsAffected > 0)
                return Ok(new { message = "Organization updated" });
            else
            {
                return BadRequest("something went wrong");
            }
        }

        [HttpDelete("{BusinessRegistrationNumber}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteOrganization(int BusinessRegistrationNumber)
        {
            var rowsAffected = await _organizationRepository.DeleteOrganization(BusinessRegistrationNumber);

            return Ok(new { message = "Organization deleted" });
        }
    }
}