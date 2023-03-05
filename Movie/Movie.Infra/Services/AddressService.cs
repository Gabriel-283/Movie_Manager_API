using AutoMapper;
using FluentResults;
using Kernel.Domain.Model.Exceptions;
using Kernel.Infra.Extensions;
using Movie.Domain.Interfaces;
using Movie.Domain.Interfaces.DaoInterfaces;
using Movie.Domain.Model.DTOs.Address;
using Movie.Domain.Model.Exceptions;
using MovieAPI.Models;
using System;
using System.Collections.Generic;

namespace Movie.Infra.Services
{
    public class AddressService : IAddressService
    {
        public IAddressDao AddressDao { get; private set; }
        public IMapper Mapper { get; private set; }

        public AddressService(IAddressDao addressDao, IMapper mapper)
        {
            AddressDao = addressDao;
            Mapper = mapper;
        }

        public Result AddAddress(AddAddressDto adressDto)
        {
            try
            {
                Address movieTheater = Mapper.Map<Address>(adressDto);

                Result result = AddressDao.Include(movieTheater);

                return result;
            }
            catch (MovieAPIException exception)
            {
                return Result.Fail(new BadRequestException(exception.Message));
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }

        public Result<Address> GetAddressById(int id)
        {
            try
            {
                if (!AddressDao.IsExistById(id))
                {
                    return ErrorResults.GetNotFoundError("Endereco não encontrado");
                }

                return Result.Ok(AddressDao.FindById(id));
            }
            catch (MovieAPIException exception)
            {
                return Result.Fail(new BadRequestException(exception.Message));
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }

        public Result<IEnumerable<Address>> ListAddress()
        {
            try
            {
                var result = AddressDao.FindAll();

                return result.ToResult();
            }
            catch (MovieAPIException exception)
            {
                return Result.Fail(new BadRequestException(exception.Message));
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }

        public Result UpdateAddress(int id, UpdateAddressDto updateAdressDto)
        {
            try
            {
                Address newAddress = Mapper.Map<Address>(updateAdressDto);

                if (!AddressDao.IsExistById(id))
                {
                    return ErrorResults.GetNotFoundError("Endereco não encontrado");
                }

                AddressDao.Update(id, newAddress);

                return Result.Ok();
            }
            catch (MovieAPIException exception)
            {
                return Result.Fail(new BadRequestException(exception.Message));
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }

        public Result DeleteAddress(int id)
        {
            try
            {
                if (!AddressDao.IsExistById(id))
                {
                    return ErrorResults.GetNotFoundError("Endereco não encontrado");
                }

                AddressDao.Exclude(id);

                return Result.Ok();
            }
            catch (MovieAPIException exception)
            {
                return Result.Fail(new BadRequestException(exception.Message));
            }
            catch (Exception exception)
            {
                return Result.Fail(new InternalException(exception.Message));
            }
        }
    }
}