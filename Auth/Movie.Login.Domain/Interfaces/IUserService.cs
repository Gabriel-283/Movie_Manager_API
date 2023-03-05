using Movie.Login.API.Models;

namespace Movie.Login.Domain.Interfaces
{
    public interface IUserService
    {
        CustomIdentityUser GetUserByEmail(string email);
        string GetUserRole(CustomIdentityUser user);
    }
}
