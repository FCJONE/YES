using Repositories.Entities;
using System.Data.Entity;
using Repositories.Abstract;

namespace Repositories.Concrete
{
    public class BookContext : BaseDbContext<Book>
    {
        public new DbSet<Book> Entities { get; set; }
    }
}
