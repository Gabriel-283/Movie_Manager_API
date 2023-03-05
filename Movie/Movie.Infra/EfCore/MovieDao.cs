using System.Collections.Generic;
using System.Linq;
using FluentResults;
using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Models;

namespace Movie.Infra.EfCore
{
    public class MovieDao : IMovieDao
    {
        public AppDbContext Context { get; private set; }

        public MovieDao(AppDbContext context)
        {
            Context = context;
        }

        public bool IsExistById(int id)
        {
            return !(FindById(id) is null);
        }

        public Result Include(MovieModel movie)
        {
            Context.Movies.Add(movie);
            Context.SaveChanges();

            return Result.Ok();
        }

        public void Exclude(int id)
        {
            var movie = FindById(id);

            Context.Remove(movie);
            Context.SaveChanges();
        }

        public IEnumerable<MovieModel> FindAll()
        {
            return Context.Movies;
        }

        public MovieModel FindById(int id)
        {
            return Context.Movies.FirstOrDefault(movie => movie.Id.Equals(id));
        }

        public void Update(int id, MovieModel newMovie)
        {
            var movie = FindById(id);

            movie.Title = newMovie.Title;
            movie.Director = newMovie.Director;
            movie.MovieKind = newMovie.MovieKind;
            movie.Duration = newMovie.Duration;

            Context.SaveChanges();
        }
    }
}
