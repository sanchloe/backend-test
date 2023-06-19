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
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAll(){
            var organizations = await _organizationRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(organizations);
        }

    }
}