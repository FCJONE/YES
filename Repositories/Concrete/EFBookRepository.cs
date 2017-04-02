using Repositories.Abstract;
using Repositories.Entities;
using System;
using System.Collections.Generic;

namespace Repositories.Concrete
{
    public class EfBookRepository : RepositoryBase<Book>
    {
        readonly EfDbContext _context = new EfDbContext();
        public IEnumerable<Book> Books => _context.Books; //On Books{get;} _context.books returned


        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
            {
                _context.Books.Add(book);
            }
            else
            {
                var dbEntry = _context.Books.Find(book.BookId);
                if (dbEntry != null)
                {
                    dbEntry.Name = book.Name;
                    dbEntry.Author = book.Author;
                    dbEntry.Description = book.Description;
                    dbEntry.Genre = book.Genre;
                    dbEntry.Price = book.Price;
                }
            }
            _context.SaveChanges();
        }

        public new IEnumerable<Book> GetEntitysList()
        {
            throw new NotImplementedException();
        }

        public new void Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public new void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public new void Save(Book entity)
        {
            throw new NotImplementedException();
        }

        public new Book GetEntity(int id)
        {
            throw new NotImplementedException();
        }
    }
}