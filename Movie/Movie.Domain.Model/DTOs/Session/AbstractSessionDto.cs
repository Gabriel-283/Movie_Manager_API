using MovieAPI.Models;
using System;

namespace MovieAPI.Data.DTOs.Session
{
    public abstract class AbstractSessionDto
    {
        public virtual MovieModel Movie { get; set; }
        public virtual Models.MovieTheater MovieTheater { get; set; }

        public int MovieId { get; set; }
        public int MovieTheaterId { get; set; }

        public DateTime EndSession { get; set; }
    }
}
