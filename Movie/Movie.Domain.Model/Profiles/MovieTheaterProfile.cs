using AutoMapper;
using MovieAPI.Data.DTOs.MovieTheater;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<AddMovieTheaterDto,MovieTheater>();
            CreateMap<MovieTheater,ReadMovieTheaterDto>();
            CreateMap<UpdateMovieTheaterDto, MovieTheater>();
        }
    }
}
