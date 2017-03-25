using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Repository
{
    public interface IAbstractRepository<T> where T : class
    {
        IEnumerable<T> GetBookList();

        void Add(T book);

        void Delete(int id);

        void Save(T book);

        T GetBook(int id);
    }
}