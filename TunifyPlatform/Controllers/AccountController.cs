using Microsoft.AspNetCore.Mvc;
using TunifyPlatform.Models.DTOs;
using TunifyPlatform.Repositories.Interfaces;
using System;
using System.Threading.Tasks;
using System.Linq;

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
            if (registerDto == null)
            {
                return BadRequest("Invalid registration request.");
            }

            var result = await _accountService.RegisterAsync(registerDto);
            if (result != null)
            {
                return CreatedAtAction(nameof(Register), new { token = result }, new { message = "User registered successfully." });
            }

            return BadRequest(new { errors = "Something went wrong" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("Invalid login request.");
            }

            try
            {
                var result = await _accountService.LoginAsync(loginDto);
                return Ok(new { token = result });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Log the exception
                // _logger.LogError(ex, "Login failed.");
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _accountService.LogoutAsync();
                return Ok(new { message = "User logged out successfully." });
            }
            catch (Exception ex)
            {
                // Log the exception
                // _logger.LogError(ex, "Logout failed.");
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
    }
}
