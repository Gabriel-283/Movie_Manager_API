using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Data.ValidatorsInterfaces;
using MovieAPI.Models;
using System;

namespace Movie.Infra.Validators
{
    public class SessionValidator : ISessionValidator
    {
        public IMovieDao MovieDao { get; private set; }
        public IMovieTheaterDao MovieTheaterDao { get; private set; }
        public SessionValidator(IMovieDao sessionDao, IMovieTheaterDao movieTheaterDao)
        {
            MovieDao = sessionDao;
            MovieTheaterDao = movieTheaterDao;
        }

        public void ValidateRequest(Session objectToValidate)
        {
            ValidateMovie(objectToValidate.MovieId);
            ValidateMovieTheater(objectToValidate.MovieTheaterId);
        }

        private void ValidateMovie(int movieId)
        {
            try
            {
                var adress = MovieDao.FindById(movieId);
                if (adress is null)
                {
                    throw new Exception("Movie not found");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private void ValidateMovieTheater(int movieTheaterId)
        {
            try
            {
                var adress = MovieTheaterDao.FindById(movieTheaterId);
                if (adress is null)
                {
                    throw new Exception("Movie theater not found");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
