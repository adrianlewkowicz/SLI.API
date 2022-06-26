using Microsoft.EntityFrameworkCore;

namespace SLI.API.Domain
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
