using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Managers.Interfaces;
using StudentsApp.Domain.Models;
using StudentsApp.Infrastructure.Interfaces;
using StudentsApp.Students.DTOs;
using StudentsApp.Students.Interfaces;
using System.Threading.Tasks;

namespace StudentsApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDto)
        {
            var user = await _userService.AuthenticateUserAsync(userLoginDto.Username, userLoginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = await _tokenService.GetTokenAsync(user.Id);
            return Ok(new { Token = token });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserLoginDTO userRegisterDto)
        {
            var user = new User
            {
                Username = userRegisterDto.Username,
                Password = userRegisterDto.Password // Using the password directly
            };

            await _userService.RegisterUserAsync(user);
            return Ok();
        }
    }
}
