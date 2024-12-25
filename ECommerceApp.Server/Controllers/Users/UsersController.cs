using ECommerceApp.Server.Controllers.Users.Dtos;
using ECommerceApp.Server.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Server.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto)
        {
            var result = await _userService.RegisterUserAsync(registerDto.Email, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User registered successfully");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginDto)
        {
            var token = await _userService.AuthenticateUserAsync(loginDto.Email, loginDto.Password);

            if (string.IsNullOrEmpty(token)) return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}
