using System;

namespace MovieAPI.Data.DTOs.Session
{
    public class ReadSessionDto 
    {
        public int Id { get; set; }
        public virtual Models.MovieModel Movie { get; set; }
        public virtual MovieAPI.Models.MovieTheater MovieTheater { get; set; }
        public DateTime EndSession { get; set; }
        public DateTime StartSession { get; set; }
    }
}
