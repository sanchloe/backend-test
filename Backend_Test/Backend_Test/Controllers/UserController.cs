using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend_Test.Repositories;
using Backend_Test.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace Backend_Test.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetById(int Id)
        {
            var user = await _userRepository.GetById(Id);
            return Ok(user);
        }
    }
}

