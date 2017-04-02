using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Repositories.Abstract
{
    public interface IAbstractRepository<T>
    {
        IEnumerable<T> GetEntitysList();

        short Add(T entity);

        short Delete(int id);

        short Save(T entity);

        short Update(T entity);

        T GetEntity(int id);
    }
}