using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Movie.Login.API.Models;
using Movie.Login.Domain.Interfaces;

namespace Movie.Login.API.Services
{
    public class TokenService : ITokenService
    {
        public CustomIdentityUser User { get; private set; }
        public string Role { get; private set; }

        public Token CreateToken(CustomIdentityUser user, string role)
        {

            User = user;
            Role = role;

            return new Token(GetStringToken());
        }

        public string GenerateResetToken(SignInManager<CustomIdentityUser> signInManager)
        {
            return signInManager.UserManager.GeneratePasswordResetTokenAsync(User).Result;
        }

        private string GetStringToken() =>
            new JwtSecurityTokenHandler().WriteToken(GetJwtToken());

        private SigningCredentials GetCredentials() => 
            new SigningCredentials(GetSecurityKey(), SecurityAlgorithms.HmacSha256);

        private SymmetricSecurityKey GetSecurityKey() => 
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajjsd09asjd09sajcnzxn"));

        private JwtSecurityToken GetJwtToken()
        {
            return new JwtSecurityToken(
                claims: GetUsersClaims(),
                signingCredentials: GetCredentials(),
                expires: DateTime.UtcNow.AddHours(1));
        }

        private Claim[] GetUsersClaims()
        {
            return new Claim[]
            {
                new Claim("username", User.UserName),
                new Claim("id",User.Id.ToString()),
                new Claim(ClaimTypes.Role,Role),
                new Claim(ClaimTypes.DateOfBirth,User.BirthDate.ToString(CultureInfo.InvariantCulture))
            };
        }
    }
}
