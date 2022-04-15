using Microsoft.EntityFrameworkCore;
using Restaurant.API.Data.Entities;

namespace Restaurant.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TableEntity> Tables { get; set; }
    }
}
