using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.DTOs.MovieTheater
{
    public abstract class AbstractMovieTheaterDto
    {

        [Required(ErrorMessage = "Field Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field AddressId is required")]
        public int AddressId { get; set; }
    }
}
