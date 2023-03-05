using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.DTOs.Movie
{
    public abstract class AbstractMovieDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field Director is required")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Field MovieKind is required")]
        public string MovieKind { get; set; }

        [Range(1, 260, ErrorMessage = "Movie must be between 1 to 260 minutes")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Field Description is required")]
        public string Description { get; set; }
        
        public int AgeGroup { get; set; }
    }
}
