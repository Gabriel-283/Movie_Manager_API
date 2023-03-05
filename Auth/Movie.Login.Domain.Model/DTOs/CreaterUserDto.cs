using System;
using System.ComponentModel.DataAnnotations;
using Movie.Login.API.Enums;

namespace Movie.Login.API.Data.DTOs
{
    public class CreaterUserDto
    {
        [Required(ErrorMessage = "Field Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Field Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Field Password Confirm is required")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Field Role is required")]
        public RolesEnums? Role { get; set; }

        [Required(ErrorMessage = "Field BirthDate is required")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
    }
};
