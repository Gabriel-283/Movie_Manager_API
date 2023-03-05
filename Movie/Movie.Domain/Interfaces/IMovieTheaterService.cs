using FluentResults;
using MovieAPI.Data.DTOs.MovieTheater;
using MovieAPI.Models;
using System.Collections.Generic;

namespace Movie.Domain.Interfaces
{
    public interface IMovieTheaterService
    {
        public Result DeleteMovieById(int id);

        public Result<MovieTheater> GetMovieTheaterById(int id);

        public Result<IEnumerable<MovieTheater>> GetMovieTheaterList();

        public Result AddMovieTheater(AddMovieTheaterDto movieTheaterDto);

        public Result UpdateMovieById(int id, UpdateMovieTheaterDto updateMovieTheaterDto);
    }
}
