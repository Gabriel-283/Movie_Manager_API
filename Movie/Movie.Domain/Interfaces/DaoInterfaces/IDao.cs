namespace Movie.Domain.Interfaces.DaoInterfaces
{
    public interface IDao<T> : ICommand<T>, IQuery<T>
    {
    }
}
