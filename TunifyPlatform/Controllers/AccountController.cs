using Microsoft.AspNetCore.Mvc;
using TunifyPlatform.Models.DTOs;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accountService;

        public AccountController(IAccount accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _accountService.RegisterAsync(registerDto);
            if (result.Succeeded)
            {
                return Ok("User registered successfully.");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var result = await _accountService.LoginAsync(loginDto);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return Ok("User logged out successfully.");
        }
    }

}
