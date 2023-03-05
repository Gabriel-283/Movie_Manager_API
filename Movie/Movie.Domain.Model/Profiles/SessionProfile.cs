using AutoMapper;
using MovieAPI.Data.DTOs.Session;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<AddSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>()
                .ForMember(dto => dto.StartSession, options => options
                .MapFrom(dto => dto.EndSession.AddMinutes(dto.Movie.Duration* (-1))));
        }
    }
}
