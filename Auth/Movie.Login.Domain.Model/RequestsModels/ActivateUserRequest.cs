using System.ComponentModel.DataAnnotations;

namespace Movie.Login.API.Data.Requests
{
    public class ActivateUserRequest
    {
        [Required]
        public string ActivationToken { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}