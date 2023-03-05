using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieAPI.Models
{
    public class MovieTheater
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "Field AddressId is required")]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Field Name is required")]
        public string Name { get; set; }

        public virtual Address Address { get; set; }

        public virtual MovieTheaterManager MovieTheaterManager { get; set; }

        [JsonIgnore]
        public int MovieTheaterManagerId { get; set; }

        //[JsonIgnore]
        public virtual List<Session> Sessions { get; set; }


    }
}
