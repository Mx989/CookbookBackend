using CookbookAPI.Models;
using CookbookAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CookbookAPI.Controllers
{

    [ApiController]
    [Route("Users")]
    public class UsersController: ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private IUsersRepository usersRepository;
        private readonly JWTSettings jwtSettings;

        public UsersController(IUsersRepository _usersRepository, ILogger<UsersController> _logger, IOptions<JWTSettings> _jwtSettings)

        {
            usersRepository = _usersRepository;
            logger = _logger;
            jwtSettings = _jwtSettings.Value;
        }

        [HttpGet("Login")]
        public async Task<ActionResult<User>> Login([FromBody] Credentials credentials)
        {
            var user = await usersRepository.GetUser(credentials.Username, credentials.Password);
            if (user == null)
            {
                return NotFound();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, credentials.Username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.JWTKey = tokenHandler.WriteToken(token);
            user.Password = null;
            return user;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task AddUser(string username, string password, string emailAddress)
        {
            await usersRepository.AddUser(username, password, emailAddress);
        }

    }
}
