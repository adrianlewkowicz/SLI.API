using Microsoft.EntityFrameworkCore;

namespace SLI.API.Domain
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<Reports> Reports { get; set; }
    }
}
