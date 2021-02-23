using CookbookAPI.Models;
using CookbookAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookbookAPI.Controllers
{

    [ApiController]
    [Route("Users")]
    public class UsersController: ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private IUsersRepository usersRepository;

        public UsersController(IUsersRepository _usersRepository, ILogger<UsersController> _logger)

        {
            usersRepository = _usersRepository;
            logger = _logger;
        }

        [Authorize]
        [HttpGet("GetUser")]
        public async Task<ActionResult<User>> GetUser()
        {
            string username = HttpContext.User.Identity.Name;

            var user = await usersRepository.GetUser(username);
            user.Password = null;

            if (user != null) return user;
            else return NotFound();
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task AddUser(string username, string password, string emailAddress)
        {
            await usersRepository.AddUser(username, password, emailAddress);
        }

    }
}
