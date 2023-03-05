using FluentResults;
using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Data.ValidatorsInterfaces;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie.Infra.EfCore
{
    public class MovieTheaterManagerDao : IMovieTheaterManagerDao
    {
        public AppDbContext Context { get; private set; }
        public IMovieTheaterManagerValidator MovieTheaterManagerValidator { get; private set; }

        public MovieTheaterManagerDao(AppDbContext context, IMovieTheaterManagerValidator movieTheaterManagerValidator)
        {
            Context = context;
            MovieTheaterManagerValidator = movieTheaterManagerValidator;
        }

        public bool IsExistById(int id)
        {
            return !(FindById(id) is null);
        }

        public Result Include(MovieTheaterManager movieTheaterManager)
        {
            try
            {
                MovieTheaterManagerValidator.ValidateRequest(movieTheaterManager);
                
                Context.MovieTheaterManager.Add(movieTheaterManager);
                Context.SaveChanges();

                return Result.Ok();
            }
            catch (Exception exception)
            {
                return Result.Fail(exception.Message);
            }
        }

        public void Exclude(int id)
        {
            try
            {
                var movie = FindById(id);

                Context.Remove(movie);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
          
        }

        public IEnumerable<MovieTheaterManager> FindAll()
        {
            return Context.MovieTheaterManager;
        }

        public MovieTheaterManager FindById(int id)
        {
            return Context.MovieTheaterManager.FirstOrDefault(movie => movie.Id.Equals(id));
        }

        public void Update(int id, MovieTheaterManager newMovieTheaterManager)
        {
            var movie = FindById(id);

            movie.Name = newMovieTheaterManager.Name;

            Context.SaveChanges();
        }
    }
}