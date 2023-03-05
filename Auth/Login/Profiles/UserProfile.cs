using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Movie.Login.API.Data.DTOs;
using Movie.Login.API.Models;

namespace Movie.Login.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreaterUserDto, User>();
            CreateMap<User, IdentityUser<int>>();
            CreateMap<User, CustomIdentityUser>();
        }
    }
}
