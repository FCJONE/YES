using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete
{
    public class EfDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
