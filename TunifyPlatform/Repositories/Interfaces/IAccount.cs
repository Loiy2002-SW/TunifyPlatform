using Microsoft.AspNetCore.Identity;
using TunifyPlatform.Models;
using TunifyPlatform.Models.DTOs;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IAccount
    {
        Task<string> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
        Task LogoutAsync();

        Task<string> GenerateJwtTokenAsync(IdentityUser user);
    }

}
