using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IAbstractRepository<T> where T : class
    {
        public IEnumerable<T> GetBookList()
        {
            throw new NotImplementedException();
        }

        public void Add(T book)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(T book)
        {
            throw new NotImplementedException();
        }

        public T GetBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
