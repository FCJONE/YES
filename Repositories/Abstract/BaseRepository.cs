using System;
using System.Collections.Generic;
using System.Data.Entity;
using Domain.Common;
using Repositories.Context;

namespace Repositories.Abstract
{
    public abstract class BaseRepository<T> :  IAbstractRepository<T> where T : EntityBase
    {
        public EfDbContext Сontext;

        protected BaseRepository(EfDbContext context)
        {
            Context = context;
        }

        public IEnumerable<T> EntitiesList(EntityBase t)
        {
            return null;
        }

        public T GetEntity(int id)
        {
            return Сontext.Find(id);
        }

        public void Add(T entity)
        {
            Сontext.Add(entity);
        }

        public void Delete(int id)
        {
            var entitiy = Сontext.Find(id);
            if (entitiy != null)
                Сontext.Remove(entitiy);
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
