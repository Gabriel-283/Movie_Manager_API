using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieAPI.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Number is required")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Field ZipCode is required")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Field Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Field Neighborhood is required")]
        public string Neighborhood { get; set; }

        [JsonIgnore]
        public virtual  MovieTheater MovieTheater { get; set; }

    }
}
