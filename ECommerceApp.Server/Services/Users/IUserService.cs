using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Server.Services.Users
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(string email, string password);
        Task<string?> AuthenticateUserAsync(string email, string password);
    }
}
