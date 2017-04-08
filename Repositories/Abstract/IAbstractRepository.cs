using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Domain.Common;
using Repositories.Context;

namespace Repositories.Abstract
{
    public interface IAbstractRepository<T> : IDisposable
    {
        
        IEnumerable<T> EntitiesList(EntityBase t);

        T GetEntity(int id);

        void Add(T entity);

        void Delete(int id);

        void Save(T entity);

        void Update(T entity);

        void Dispose(bool disposing);
    }
}