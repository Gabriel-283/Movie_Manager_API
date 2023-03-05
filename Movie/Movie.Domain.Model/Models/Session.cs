using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public virtual MovieModel Movie { get; set; }
        public virtual MovieTheater MovieTheater { get; set; }
        
        public int MovieId { get; set; }
        public int MovieTheaterId { get; set; }

        public DateTime EndSession { get; set; }
    }
}
