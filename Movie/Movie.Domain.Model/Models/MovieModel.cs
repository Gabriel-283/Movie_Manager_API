using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieAPI.Models
{
    public class MovieModel
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
        
        [Required(ErrorMessage = "Field Description is required")]
        public string Description { get; set; }

        [Range(1, 360, ErrorMessage = "Movie must be between 1 to 260 minutes")]
        public int Duration { get; set; }

        [Range(5, 18, ErrorMessage = "Movie age group need be between 5 to 18 years old")]
        public int AgeGroup { get; set; }

        [JsonIgnore]
        public virtual List<Session> Sessions { get; set; }
    }
}
