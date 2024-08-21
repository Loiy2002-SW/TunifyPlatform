using Microsoft.AspNetCore.Identity;
using TunifyPlatform.Models.DTOs;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IAccount
    {
        Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
        Task LogoutAsync();
    }

}
