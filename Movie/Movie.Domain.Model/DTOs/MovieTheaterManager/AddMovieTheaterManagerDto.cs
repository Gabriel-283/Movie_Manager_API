using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.DTOs.MovieTheaterManager
{
    public class AddMovieTheaterManagerDto
    {
        [Required(ErrorMessage = "Field Name is required")]
        public string Name { get; set; }
    }
}
