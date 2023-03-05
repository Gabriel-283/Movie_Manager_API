using AutoMapper;
using FluentResults;
using Kernel.Domain.Model.Exceptions;
using Kernel.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Movie.Login.API.Data.DTOs;
using Movie.Login.API.Data.Requests;
using Movie.Login.API.Enums;
using Movie.Login.API.Models;
using Movie.Login.Domain.Interfaces;
using System;
using System.Linq;
using System.Web;

namespace Movie.Login.API.Services
{
    public class RegisterService : IRegisterService
    {
        public IMapper Mapper { get; private set; }
        public IEmailTokenSender EmailService { get; private set; }
        public UserManager<CustomIdentityUser> UserManager { get; private set; }

        public RegisterService(IMapper mapper,
            IEmailTokenSender emailService,
            UserManager<CustomIdentityUser> userManager)
        {
            Mapper = mapper;
            EmailService = emailService;
            UserManager = userManager;
        }

        public Result RegisterUser(CreaterUserDto createUserDto)
        {
            try
            {
                User user = Mapper.Map<User>(createUserDto);
                if (!IsValidRole(user.Role))
                {
                    return Result.Fail($"Role invalida");
                }
                
                CustomIdentityUser userIdentity = Mapper.Map<CustomIdentityUser>(user);

                var result = UserManager.CreateAsync(userIdentity, createUserDto.Password);

                return result.Result.Succeeded ? GenerateToken(userIdentity)
                                               : Result.Fail($"Erro ao tentar cadastra usuario: {result.Result.Errors.FirstOrDefault()?.Code}");
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }

        private bool IsValidRole(RolesEnums role)
        {
            return Enum.IsDefined(role);
        }

        private Result GenerateToken(CustomIdentityUser userIdentity)
        {
            var code = UserManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;
            var encodedCode = HttpUtility.UrlEncode(code);

            EmailService.SendTokenOnEmail(new[] { userIdentity.Email }, "Link", userIdentity.Id, encodedCode);

            return Result.Ok().WithSuccess(code);
        }

        public Result ActivateUSer(ActivateUserRequest request)
        {
            try
            {
                var userIdentity = UserManager.Users.FirstOrDefault(user => user.Id.Equals(request.UserId));

                var result = UserManager.ConfirmEmailAsync(userIdentity, request.ActivationToken).Result;

                bool isExpiredToken = result.Errors.Any(error => error.Code.ToUpper().Contains("TOKEN"));
                if (isExpiredToken)
                {
                    GenerateToken(userIdentity);

                    return Result.Fail("Token Expirado, novo token enviado");
                }

                return result.Succeeded ? Result.Ok() : Result.Fail(result.Errors.First().Description);
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }
    }
}
