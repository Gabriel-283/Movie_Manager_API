using FluentResults;
using Movie.Login.API.Data.DTOs;
using Movie.Login.API.Data.Requests;

namespace Movie.Login.Domain.Interfaces
{
    public interface IRegisterService
    {
        Result RegisterUser(CreaterUserDto createUserDto);

        Result ActivateUSer(ActivateUserRequest request);
    }
}
