using MovieAPI.Models;

namespace Movie.Domain.Interfaces.DaoInterfaces
{
    public interface ISessionDao : ICommand<Session>, IQuery<Session>
    {
    }
}
