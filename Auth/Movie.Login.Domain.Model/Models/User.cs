using System;
using Movie.Login.API.Enums;

namespace Movie.Login.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public RolesEnums Role { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
