using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.DTOs.Session
{
    public class AddSessionDto
    {
        [Required(ErrorMessage = "Field MovieId is required")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Field MovieTheaterId is required")]
        public int MovieTheaterId { get; set; }

        [Required(ErrorMessage = "Field EndSession is required")]
        public DateTime EndSession { get; set; }
    }
}
