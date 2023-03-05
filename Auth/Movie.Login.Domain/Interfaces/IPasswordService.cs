using FluentResults;
using Movie.Login.API.Data.Requests;

namespace Movie.Login.Domain.Interfaces
{
    public interface IPasswordService
    {
        Result SetNewPassword(SetNewPasswordRequest request);
        Result RequestPasswordReset(ResetPasswordRequest request);
    }
}
