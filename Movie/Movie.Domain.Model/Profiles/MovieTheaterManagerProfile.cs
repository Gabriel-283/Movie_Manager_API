using AutoMapper;
using MovieAPI.Data.DTOs.MovieTheaterManager;
using MovieAPI.Models;
using System.Linq;

namespace MovieAPI.Profiles
{
    public class MovieTheaterManagerProfile : Profile
    {
        public MovieTheaterManagerProfile()
        {
            CreateMap<AddMovieTheaterManagerDto, MovieTheaterManager>();
            CreateMap<MovieTheaterManager, ReadMovieTheaterManagerDto>()
                                                                        .ForMember(movieTheaterManager => movieTheaterManager.MovieTheaters,  options => options 
                                                                        .MapFrom(movieTheaterManager => movieTheaterManager.MovieTheaters
                                                                        .Select(c => new { c.Id,c.Name,c.AddressId} )));

        }
    }
}
