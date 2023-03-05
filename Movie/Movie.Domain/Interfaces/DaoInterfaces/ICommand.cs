using FluentResults;

namespace Movie.Domain.Interfaces.DaoInterfaces
{
    public interface ICommand<T>
    {
        Result Include(T obj);
        void Update(int id,T newObj);
        void Exclude(int id);
    }
}
