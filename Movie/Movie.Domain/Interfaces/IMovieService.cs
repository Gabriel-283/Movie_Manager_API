using FluentResults;
using MovieAPI.Data.DTOs.Movie;
using MovieAPI.Models;
using System.Collections.Generic;

namespace Movie.Domain.Interfaces
{
    public interface IMovieService
    {
        public Result AddMovie(AddMovieDto movieDto);

        public Result<IEnumerable<MovieModel>> GetMoviesList();

        public Result<MovieModel> GetMovieById(int id);

        public Result UpdateMovieById(int id, MovieModel newMovie);

        public Result DeleteMovieById(int id);
    }
}
