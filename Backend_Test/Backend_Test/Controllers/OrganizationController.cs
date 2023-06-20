using System;
using Backend_Test.Models;
using Backend_Test.Repositories;
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

        public OrganizationController(OrganizationRepository organizationRepository){
            _organizationRepository = organizationRepository;
        }

        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Organization>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAll(){
            var organizations = await _organizationRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(organizations);
        }

        [HttpGet("{BusinessRegistrationNumber}")]
        [ProducesResponseType(200, Type = typeof(Organization))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetById(int BusinessRegistrationNumber)
        {
            var user = await _organizationRepository.GetById(BusinessRegistrationNumber);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganization(Organization organization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rowsAffected = await _organizationRepository.CreateOrganization(organization);

            if (rowsAffected > 0)
                return Ok(new { message = "Organization created" });
            else {
                return BadRequest("something went wrong");
            }
        }
    }
}