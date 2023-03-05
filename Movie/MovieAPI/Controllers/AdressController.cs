using AutoMapper;
using FluentResults;
using Kernel.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Interfaces;
using Movie.Domain.Model.DTOs.Address;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdressController : AbstractController
    {
        private IAddressService _addressService;

        public AdressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] AddAddressDto adressDto)
        {
            Result result = _addressService.AddAddress(adressDto);

            return result.IsFailed ? GetErrorResult(result) : Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAddresById(int id)
        {
            var result = _addressService.GetAddressById(id);

            return result.IsFailed ? GetErrorResult(result) : Ok(result.Value);
        }

        [HttpGet]
        public IActionResult GetAddresList()
        {
            var result = _addressService.ListAddress();

            return result.IsSuccess ? Ok(result.Value) : GetErrorResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddressById(int id, [FromBody] UpdateAddressDto updateAdressDto)
        {
            var result = _addressService.UpdateAddress(id, updateAdressDto);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddressById(int id)
        {
            var result = _addressService.DeleteAddress(id);

            return result.IsSuccess ? Ok() : GetErrorResult(result);
        }
    }
}