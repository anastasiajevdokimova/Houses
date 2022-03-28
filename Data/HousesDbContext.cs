using Houses.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Houses.Data
{
    public class HousesDbContext : DbContext
    {
        public HousesDbContext(DbContextOptions<HousesDbContext> options) : base(options) { }

        public DbSet<House> House { get; set; }
    }
}
