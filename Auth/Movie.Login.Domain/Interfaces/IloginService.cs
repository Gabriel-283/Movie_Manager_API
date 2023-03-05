using FluentResults;
using Movie.Login.API.Data.Requests;

namespace Movie.Login.Domain.Interfaces
{
    public interface ILoginService
    {
        Result LoginUser(LoginRequest request);
    }
}
