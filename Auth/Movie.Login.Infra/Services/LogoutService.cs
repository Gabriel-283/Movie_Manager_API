using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using Movie.Login.API.Models;
using Movie.Login.Domain.Interfaces;
using Kernel.Domain.Model.Exceptions;

namespace Movie.Login.API.Services
{
    public class LogoutService : ILogoutService
    {
        private readonly SignInManager<CustomIdentityUser> _signInManager;

        public LogoutService(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogoutUser()
        {
            try
            {
                var result = _signInManager.SignOutAsync();

                return result.IsCompletedSuccessfully ? Result.Ok() : Result.Fail($"{result.Exception.Message}");
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }
    }
}
