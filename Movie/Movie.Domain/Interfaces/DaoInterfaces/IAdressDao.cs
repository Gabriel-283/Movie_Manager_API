using MovieAPI.Models;

namespace Movie.Domain.Interfaces.DaoInterfaces
{
    public interface IAddressDao : ICommand<Address>, IQuery<Address>
    {
    }
}
