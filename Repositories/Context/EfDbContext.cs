using System.Data.Entity;
using Domain;

namespace Repositories.Context
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("ApplicationServices")
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Cart> Carts { get; set; }


    }
}
