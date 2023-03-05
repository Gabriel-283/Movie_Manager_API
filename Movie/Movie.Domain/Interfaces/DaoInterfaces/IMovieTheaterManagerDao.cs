using MovieAPI.Models;

namespace Movie.Domain.Interfaces.DaoInterfaces
{
    public interface IMovieTheaterManagerDao : ICommand<MovieTheaterManager>, IQuery<MovieTheaterManager>
    {
    }
}
