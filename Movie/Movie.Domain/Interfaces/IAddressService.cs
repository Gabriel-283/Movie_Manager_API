using FluentResults;
using Movie.Domain.Model.DTOs.Address;
using MovieAPI.Models;
using System.Collections.Generic;

namespace Movie.Domain.Interfaces
{
    public interface IAddressService
    {
        Result AddAddress(AddAddressDto adressDto);
        
        Result<Address> GetAddressById(int id);
        
        Result<IEnumerable<Address>> ListAddress();
        
        Result UpdateAddress(int id, UpdateAddressDto updateAdressDto);
        
        Result DeleteAddress(int id);
    }
}