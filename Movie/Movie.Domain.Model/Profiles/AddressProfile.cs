using AutoMapper;
using Movie.Domain.Model.DTOs.Address;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddAddressDto,Address>();
            CreateMap<Address,ReadAddressDto>();
            CreateMap<UpdateAddressDto,Address>();
        }
    }
}
