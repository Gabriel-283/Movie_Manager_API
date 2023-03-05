using Microsoft.AspNetCore.Identity;
using Movie.Login.API.Models;
using Movie.Login.Domain.Interfaces;
using System;
using System.Linq;

namespace Movie.Login.Infra.Services
{
    public class UserService : IUserService
    {
        public SignInManager<CustomIdentityUser> SignInManager { get; private set; }

        public UserService(SignInManager<CustomIdentityUser> signInManager)
        {
            SignInManager = signInManager;
        }

        public CustomIdentityUser GetUserByEmail(string email)
        {
            return SignInManager.UserManager
                                    .Users
                                    .FirstOrDefault(user => user
                                    .NormalizedEmail
                                    .Equals(email.ToUpper()));
        }

        public string GetUserRole(CustomIdentityUser user)
        {
            return SignInManager.UserManager
                                .GetRolesAsync(user)
                                .Result
                                .FirstOrDefault();
        }
    }
}
