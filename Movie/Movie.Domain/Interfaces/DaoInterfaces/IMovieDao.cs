using MovieAPI.Models;

namespace Movie.Domain.Interfaces.DaoInterfaces
{
    public interface IMovieDao : ICommand<MovieModel>, IQuery<MovieModel>
    {
    }
}
