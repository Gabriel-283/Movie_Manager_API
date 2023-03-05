using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Data.ValidatorsInterfaces;
using MovieAPI.Models;

namespace Movie.Infra.Validators
{
    public class AddressValidator : IAddressValidator
    {
        public IMovieDao MovieDao { get; private set; }
        public IMovieTheaterDao MovieTheaterDao { get; private set; }

        public AddressValidator(IMovieDao sessionDao, IMovieTheaterDao movieTheaterDao)
        {
            MovieDao = sessionDao;
            MovieTheaterDao = movieTheaterDao;
        }

        public void ValidateRequest(Address objectToValidate)
        {
            
        }
    }
}
