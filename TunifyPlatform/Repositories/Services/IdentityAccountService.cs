using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TunifyPlatform.Models;
using TunifyPlatform.Models.DTOs;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class IdentityAccountService : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public IdentityAccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<string> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User { UserName = registerDto.Username, Email = registerDto.Email };
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                // Generate JWT token after successful registration
                var token = await GenerateJwtTokenAsync(user);
                return token;
            }

            return null;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // Retrieve the user to generate token
                var user = await _userManager.FindByNameAsync(loginDto.Username);
                if (user != null)
                {
                    var token = await GenerateJwtTokenAsync(user);
                    return token;
                }

                throw new UnauthorizedAccessException("User not found.");
            }
            throw new UnauthorizedAccessException("Invalid login attempt.");
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> GenerateJwtTokenAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User is null");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
            };

            // Add user roles as claims
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Ensure JWTService.GenerateToken accepts these parameters
            return JWTService.GenerateToken(user.Id, claims, _configuration);
        }
    }
}
