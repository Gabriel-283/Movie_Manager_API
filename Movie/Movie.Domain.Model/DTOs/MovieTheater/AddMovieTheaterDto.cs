using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Data.DTOs.MovieTheater
{
    public class AddMovieTheaterDto : AbstractMovieTheaterDto
    {
        [Required(ErrorMessage = "Field MovieTheaterManagerId is required")]
        public int MovieTheaterManagerId { get; set; }

        public virtual Models.Address Address { get; set; }
    }
}
