using System.ComponentModel.DataAnnotations;

namespace Movie.Login.API.Data.Requests
{
    public class ResetPasswordRequest
    {
        [Required] 
        public string Email { get; set; }
    }
}