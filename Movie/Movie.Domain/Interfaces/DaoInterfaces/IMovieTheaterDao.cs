using MovieAPI.Models;

namespace Movie.Domain.Interfaces.DaoInterfaces
{
    public interface IMovieTheaterDao : ICommand<MovieTheater>, IQuery<MovieTheater>
    {
    }
}
