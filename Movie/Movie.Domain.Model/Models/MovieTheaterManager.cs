using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class MovieTheaterManager
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<MovieTheater> MovieTheaters { get; set; }
    }
}
