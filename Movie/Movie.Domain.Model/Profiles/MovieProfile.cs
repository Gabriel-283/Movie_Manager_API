using AutoMapper;
using MovieAPI.Data.DTOs.Movie;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class movieProfile : Profile
    {
        public movieProfile()
        {
            CreateMap<AddMovieDto, MovieModel>();
            CreateMap<MovieModel, ReadMovieDto>();
            CreateMap<UpdateMovieDto, MovieModel>();
        }
    }
}
