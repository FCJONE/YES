using System;
using System.Collections.Generic;

namespace Repositories.Abstract
{
    public abstract class RepositoryBase<T> : IAbstractRepository<T>
    {
        public IEnumerable<T> GetEntitysList()
        {
            throw new NotImplementedException();
        }

        public short Add(T entity)
        {
            throw new NotImplementedException();
        }

        public short Delete(int id)
        {
            throw new NotImplementedException();
        }

        public short Save(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public short Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
