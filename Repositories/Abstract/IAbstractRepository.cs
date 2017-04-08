using System;
using System.Collections.Generic;

namespace Repositories.Abstract
{
    public interface IAbstractRepository<T> : IDisposable
    {
        IEnumerable<T> EntitiesList();

        T GetEntity(int id);

        void Add(T entity);

        void Delete(int id);

        void Save(T entity);

        void Update(T entity);

        void Dispose(bool disposing);

        new void Dispose();
    }
}