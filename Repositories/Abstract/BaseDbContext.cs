using System.Data.Entity;

namespace Repositories.Abstract
{
    public abstract class BaseDbContext<T> : DbContext  where T : class
    {
        public DbSet<T> Entities { get; set; }
    }
}
