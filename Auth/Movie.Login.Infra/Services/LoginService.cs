using FluentResults;
using Kernel.Domain.Model.Exceptions;
using Kernel.Infra.Extensions;
using Microsoft.AspNetCore.Identity;
using Movie.Login.API.Data.Requests;
using Movie.Login.API.Models;
using Movie.Login.Domain.Interfaces;
using System;

namespace Movie.Login.API.Services
{
    public class LoginService: ILoginService
    {
        public IUserService UserService { get; private set; }
        public ITokenService TokenService { get; private set; }
        public SignInManager<CustomIdentityUser> SignInManager { get; set; }

        public LoginService(IUserService userService, SignInManager<CustomIdentityUser> signInManager, ITokenService tokenService)
        {
            UserService = userService;
            TokenService = tokenService;
            SignInManager = signInManager;
        }

        public LoginService(IUserService userService)
        {
            UserService = userService;
        }

        public Result LoginUser(LoginRequest request)
        {
            try
            {
                var identityUser = UserService.GetUserByEmail(request.Email);
                if (identityUser is null) return ErrorResults.GetInvalidUserResult();

                var result = SignInManager.PasswordSignInAsync(identityUser.UserName,
                    request.Password, false, false);

                if (!result.Result.Succeeded) return ErrorResults.GetInvalidUserResult();

                var userRole = UserService.GetUserRole(identityUser);
                var token = TokenService.CreateToken(identityUser,userRole);

                return result.Result.Succeeded
                    ? Result.Ok().WithSuccess(token.Value)
                    : ErrorResults.GetInvalidUserResult();
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }
    }
}
