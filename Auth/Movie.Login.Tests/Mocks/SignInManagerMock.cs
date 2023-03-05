using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Movie.Login.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Login.Tests.Mocks
{
    public class SignInManagerMock
    {
        public class FakeSignInManager : SignInManager<CustomIdentityUser>
        {
            public FakeSignInManager()
                    : base(new FakeUserManager(),
                         new Mock<IHttpContextAccessor>().Object,
                         new Mock<IUserClaimsPrincipalFactory<CustomIdentityUser>>().Object,
                         new Mock<IOptions<IdentityOptions>>().Object,
                         new Mock<ILogger<SignInManager<CustomIdentityUser>>>().Object,
                         new Mock<IAuthenticationSchemeProvider>().Object)
            { }

            public override Task<SignInResult> PasswordSignInAsync(CustomIdentityUser user, string password, bool isPersistent, bool lockoutOnFailure)
            {
                return base.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
            }
        }

        public class FakeUserManager : UserManager<CustomIdentityUser>
        {
            public FakeUserManager()
                : base(new Mock<IUserStore<CustomIdentityUser>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<IPasswordHasher<CustomIdentityUser>>().Object,
                  new IUserValidator<CustomIdentityUser>[0],
                  new IPasswordValidator<CustomIdentityUser>[0],
                  new Mock<ILookupNormalizer>().Object,
                  new Mock<IdentityErrorDescriber>().Object,
                  new Mock<IServiceProvider>().Object,
                  new Mock<ILogger<UserManager<CustomIdentityUser>>>().Object)
            { }

            public override IQueryable<CustomIdentityUser> Users
            {
                get
                {
                    var d = new List<CustomIdentityUser>()
                    {
                        new CustomIdentityUser()
                        {
                            NormalizedEmail = "Teste"
                        }
                    };
                    
                    return new EnumerableQuery<CustomIdentityUser>(d);
                }
            }

            public override Task<IdentityResult> CreateAsync(CustomIdentityUser user, string password)
            {
                return Task.FromResult(IdentityResult.Success);
            }

            public override Task<IdentityResult> AddToRoleAsync(CustomIdentityUser user, string role)
            {
                return Task.FromResult(IdentityResult.Success);
            }

            public override Task<IdentityResult> ResetPasswordAsync(CustomIdentityUser user, string token, string newPassword)
            {
                return Task.FromResult(IdentityResult.Success);
            }

            public override Task<string> GenerateEmailConfirmationTokenAsync(CustomIdentityUser user)
            {
                return Task.FromResult(Guid.NewGuid().ToString());
            }

        }
    }
}
