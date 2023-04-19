﻿using Microsoft.AspNetCore.Mvc;
using ServisUser.Interface;
using ServisUser.Model;

namespace ServisUser.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class UserController : Controller
    {
        private readonly IUserRepository<User> _repository;

        public UserController(IUserRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet("users")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> GetUser()
        {
            var users = await _repository.GetUsers();

            if (users.Count == 0)
                return NotFound();

            return Ok(users);
        }
    }
}
