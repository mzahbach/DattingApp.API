using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserforRegisterDto userforRegisterDto)
        {
            //validate request
            userforRegisterDto.Username = userforRegisterDto.Username.ToLower();



            if (await _repo.UserExists(userforRegisterDto.Username))
                return BadRequest("username already exists");



            var userToCreate = new User
            {
                Username = userforRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userforRegisterDto.Password);


            return StatusCode(201);



        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
           
            var userFromRepo = await _repo.Login(userForLoginDto.username.ToLower(), userForLoginDto.password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username.ToString())
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creads = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creads
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token =tokenHandler.CreateToken(tokenDescriptor);


            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });

            
            }


           
        }

    
}