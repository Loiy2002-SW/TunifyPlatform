using Microsoft.AspNetCore.Identity;
using TunifyPlatform.Models.DTOs;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class IdentityAccountService : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityAccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
        {
            var user = new IdentityUser { UserName = registerDto.Username, Email = registerDto.Email };
            return await _userManager.CreateAsync(user, registerDto.Password);
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return "Login successful";
            }
            throw new UnauthorizedAccessException("Invalid login attempt.");
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();

        }
    }

}
