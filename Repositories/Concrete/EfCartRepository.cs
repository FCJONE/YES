using Domain;
using Repositories.Abstract;
using Repositories.Context;
using Repositories.Entities;

namespace Repositories.Concrete
{
    internal class EfCartRepository : BaseRepository<Cart>
    {
        private readonly EfDbContext _efCartContext;

        public EfCartRepository(EfDbContext efCartContext)
        {
            _efCartContext = efCartContext;
        }

        public void AddItem(Book book, int quantity)
        {
            var line = _lineCollection.FirstOrDefault(b => b.Book.BookId == book.BookId);

            if (line != null)
                line.Quantity += quantity;
            else
                _lineCollection.Add(new CartLine { Book = book, Quantity = quantity });
        }

        public void RemoveLine(Book book)
        {
            _lineCollection.RemoveAll(l => l.Book.BookId == book.BookId);
        }


        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(e => e.Book.Price * e.Quantity);
        }


        public void Clear()
        {
            _lineCollection.Clear();
        }
    }
}
