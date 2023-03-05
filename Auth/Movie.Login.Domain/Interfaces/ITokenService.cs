using Microsoft.AspNetCore.Identity;
using Movie.Login.API.Models;

namespace Movie.Login.Domain.Interfaces
{
    public interface ITokenService
    {
        Token CreateToken(CustomIdentityUser user, string role);
        string GenerateResetToken(SignInManager<CustomIdentityUser> signInManager);
    }
}
