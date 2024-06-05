using graphs_ms.Models;
using Microsoft.EntityFrameworkCore;

namespace graphs_ms.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
