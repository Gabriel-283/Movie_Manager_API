using System;
using Microsoft.AspNetCore.Identity;

namespace Movie.Login.API.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime BirthDate { get; set; }
    }
}