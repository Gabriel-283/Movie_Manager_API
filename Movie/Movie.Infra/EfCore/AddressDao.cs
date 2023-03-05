using FluentResults;
using Kernel.Infra.Extensions;
using Movie.Domain.Interfaces.DaoInterfaces;
using MovieAPI.Data.ValidatorsInterfaces;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie.Infra.EfCore
{
    public class  AddressDao : IAddressDao
    {
        public AppDbContext Context { get; private set; }
        public IAddressValidator AddressValidator { get; private set; }

        public AddressDao(AppDbContext context, IAddressValidator addressValidator)
        {
            Context = context;
            AddressValidator = addressValidator;
        }

        public void Exclude(int id)
        {
            var address = FindById(id);

            Context.Remove(address);
            Context.SaveChanges();
        }

        public IEnumerable<Address> FindAll()
        {
            return Context.Address;
        }

        public Address FindById(int id)
        {
            return Context.Address.FirstOrDefault(address => address.Id.Equals(id));
        }

        public Result Include(Address addresObject)
        {
            try
            {
                var existAddreses = Context.Address.FirstOrDefault(x => x.Street == addresObject.Street && 
                                                            x.Neighborhood == addresObject.Neighborhood &&
                                                            x.Number == addresObject.Number);

                if (existAddreses != null && existAddreses != default)
                {
                    return ErrorResults.GeBadRequestError("Endereço já existente");
                }

                Context.Address.Add(addresObject);

                int result = Context.SaveChanges();

                return Result.OkIf(result.Equals(Context.SuccededResultNumber), Context.DefaultErrorSaveMessage);
            }
            catch (Exception exception)
            {
                return Result.Fail(exception.Message);
            }

        }

        public bool IsExistById(int id)
        {
            return !(FindById(id) is null);
        }

        public void Update(int id, Address newObj)
        {
            var address = FindById(id);

            address.Street = newObj.Street;
            address.Number = newObj.Number;
            address.ZipCode = newObj.ZipCode;
            address.Neighborhood = newObj.Neighborhood;

            Context.SaveChanges();
        }
    }
}
