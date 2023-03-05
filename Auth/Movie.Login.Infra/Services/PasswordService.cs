using FluentResults;
using Kernel.Domain.Model.Exceptions;
using Kernel.Infra.Extensions;
using Microsoft.AspNetCore.Identity;
using Movie.Login.API.Data.Requests;
using Movie.Login.API.Models;
using Movie.Login.Domain.Interfaces;
using System;

namespace Movie.Login.Infra.Services
{
    public class PasswordService : IPasswordService
    {
        public IUserService UserService { get; private set; }
        public ITokenService TokenService { get; private set; }
        public SignInManager<CustomIdentityUser> SignInManager { get; set; }

        public PasswordService(IUserService userService,ITokenService tokenService, SignInManager<CustomIdentityUser> signInManager)
        {
            UserService = userService;
            TokenService = tokenService;
            SignInManager = signInManager;
        }

        public Result RequestPasswordReset(ResetPasswordRequest request)
        {
            try
            {
                CustomIdentityUser identityUser = UserService.GetUserByEmail(request.Email);

                return identityUser is null ? ErrorResults.GetInvalidUserResult()
                                            : Result.Ok().WithSuccess(TokenService.GenerateResetToken(SignInManager));

            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }

        public Result SetNewPassword(SetNewPasswordRequest request)
        {
            try
            {
                CustomIdentityUser identityUser = UserService.GetUserByEmail(request.Email);

                if (identityUser is null) return ErrorResults.GetInvalidUserResult();

                IdentityResult result = SignInManager.UserManager.ResetPasswordAsync(identityUser, request.Token,request.Password).Result;

                return result.Succeeded ? Result.Ok().WithSuccess("Senha alterada com sucesso")
                                        : Result.Fail("Falha ao tentar alterar senha");
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }
    }
}
