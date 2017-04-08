using System;
using System.Collections.Generic;
using System.Data.Entity;
using Repositories.Concrete;

namespace Repositories.Abstract
{
    public abstract class BaseRepository<T> : IAbstractRepository<T> where T : class
    {
        public BaseDbContext<T> Сontext;


        public IEnumerable<T> EntitiesList()
        {
            return Сontext.Entities;
        }

        public T GetEntity(int id)
        {
            return Сontext.Entities.Find(id);
        }

        public void Add(T entity)
        {
            Сontext.Entities.Add(entity);
        }

        public void Delete(int id)
        {
            var entitiy = Сontext.Entities.Find(id);
            if (entitiy != null)
                Сontext.Entities.Remove(entitiy);
        }

        public void Save(T entity)
        {
            Сontext.SaveChanges();
        }

        public void Update(T entity)
        {
            Сontext.Entry(entity).State = EntityState.Modified;
        }



        private bool _disposed;
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                Сontext.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
