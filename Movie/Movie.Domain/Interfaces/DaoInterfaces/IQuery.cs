using System.Collections.Generic;

namespace Movie.Domain.Interfaces.DaoInterfaces
{
    public interface IQuery<T>
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        bool IsExistById(int id);
    }
}
