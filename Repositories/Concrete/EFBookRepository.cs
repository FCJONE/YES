using Repositories.Abstract;
using Repositories.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using Domain;
using Repositories.Context;

namespace Repositories.Concrete
{
    public class EfBookRepository : BaseRepository<Book>
    {

        private readonly EfDbContext _efBookContext;

        public EfBookRepository(EfDbContext efBookContext)
        {
            _efBookContext = efBookContext;
        }


        /// <summary>
        /// Ну хр его знает, что это такое
        /// </summary>
        /// <param name="book"></param>
        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
            {
                _efBookContext.Books.Add(book);
            }
            else
            {
                var dbEntry = _efBookContext.Books.Find(book.BookId);
                if (dbEntry != null)
                {
                    dbEntry.Name = book.Name;
                    dbEntry.Author = book.Author;
                    dbEntry.Description = book.Description;
                    dbEntry.Genre = book.Genre;
                    dbEntry.Price = book.Price;
                }
            }
            _efBookContext.SaveChanges();
        }


        public IEnumerable<Book> GetEntitysList()
        {
            return EntitiesList();
        }


        public void AddBook(Book entity)
        {
            Add(entity);
        }


        public void DeleteBook(int id)
        {
            Delete(id);
        }


        public Book GetBook(int id)
        {
            return GetEntity(id);
        }
    }
}