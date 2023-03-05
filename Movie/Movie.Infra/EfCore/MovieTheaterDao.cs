using FluentResults;
using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Data.ValidatorsInterfaces;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie.Infra.EfCore
{
    public class MovieTheaterDao : IMovieTheaterDao
    {
        public AppDbContext Context { get; private set; }
        public IMovieTheaterDaoValidator MovieTheaterDaoValidator { get; private set; }

        public MovieTheaterDao(AppDbContext context,IMovieTheaterDaoValidator movieTheaterDaoValidator)
        {
            Context = context;
            MovieTheaterDaoValidator = movieTheaterDaoValidator;
        }

        public void Exclude(int id)
        {
            var movieTheater = FindById(id);

            Context.Remove(movieTheater);
            Context.SaveChanges();
        }

        public IEnumerable<MovieTheater> FindAll()
        {
            return Context.MovieTheater;
        }

        public MovieTheater FindById(int id)
        {
            return Context.MovieTheater.FirstOrDefault(movieTheater => movieTheater.Id.Equals(id));
        }

        public Result Include(MovieTheater movieTheaterovieTheaterObject)
        {
            try
            {
                MovieTheaterDaoValidator.ValidateRequest(movieTheaterovieTheaterObject);

                Context.MovieTheater.Add(movieTheaterovieTheaterObject);
                var result = Context.SaveChanges();

                return Result.OkIf(result.Equals(Context.SuccededResultNumber), Context.DefaultErrorSaveMessage);
            }
            catch (Exception exception)
            {
                return Result.Fail(exception.Message);
            }
        }

        public bool IsExistById(int id)
        {
            return !(FindById(id) is null);
        }

        public void Update(int id, MovieTheater newObj)
        {
            var movieTheater = FindById(id);

            movieTheater.Name = newObj.Name;
            movieTheater.Address = newObj.Address;
        }
    }
}