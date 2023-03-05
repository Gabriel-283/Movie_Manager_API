using Movie.Domain.Model.Exceptions;
using Movie.Infra.EfCore;
using MovieAPI.Data.ValidatorsInterfaces;
using MovieAPI.Models;
using System;
using System.Linq;

namespace Movie.Infra.Validators
{
    public class MovieTheaterDaoValidator : IMovieTheaterDaoValidator
    {
        public AppDbContext Context { get; private set; }

        public MovieTheaterDaoValidator(AppDbContext context)
        {
            Context = context;
        }
        
        public void ValidateRequest(MovieTheater movieTheaterObject)
        {
            ValidateAddress(movieTheaterObject.AddressId);
            ValidateMovieTheaterManager(movieTheaterObject.MovieTheaterManagerId);
        }
       
        public void ValidateAddress(int addressId)
        {
            try
            {
                var adress = Context.Address.FirstOrDefault(address => address.Id.Equals(addressId));
                if (adress is null)
                {
                    throw new MovieAPIException("Endereco nao encontrado");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        
        public void ValidateMovieTheaterManager(int movieTheaterManagerId)
        {
            try
            {
                var movieTheaterManager = Context.MovieTheaterManager.FirstOrDefault(movie => movie.Id.Equals(movieTheaterManagerId));
                if (movieTheaterManager is null)
                {
                    throw new MovieAPIException("Gerente de cinema não encontrado");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}