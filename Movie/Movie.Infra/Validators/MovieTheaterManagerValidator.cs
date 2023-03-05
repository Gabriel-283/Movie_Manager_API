using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Data.ValidatorsInterfaces;
using MovieAPI.Models;

namespace Movie.Infra.Validators
{
    public class MovieTheaterManagerValidator : IMovieTheaterManagerValidator
    {
        public IMovieTheaterDao MovieTheaterDao { get; private set; }
        public MovieTheaterManagerValidator(IMovieTheaterDao movieTheaterDao)
        {
            MovieTheaterDao = movieTheaterDao;
        }

        public void ValidateRequest(MovieTheaterManager objectToValidate)
        {
            ValidateMovieTheater(objectToValidate.Id);
        }

        private void ValidateMovieTheater(int movieTheaterId)
        {
            // try
            // {
            //     var movieTheater = MovieTheaterDao.FindById(movieTheaterId);
            //     if (movieTheater is null)
            //     {
            //         throw new Exception("Movie theater not found");
            //     }
            // }
            // catch (Exception exception)
            // {
            //     throw new Exception(exception.Message);
            // }
        }
    }
}
