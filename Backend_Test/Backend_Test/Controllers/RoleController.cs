using System;
using Backend_Test.Models;
using Backend_Test.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Test.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : Controller
    {

        private RoleRepository _roleRepository;
        public RoleController(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(roles);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Role))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetById(int Id)
        {
            var user = await _roleRepository.GetById(Id);
            return Ok(user);
        }
    }
}

