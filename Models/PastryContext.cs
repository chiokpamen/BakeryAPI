using Microsoft.EntityFrameworkCore;

namespace BakeryAPI.Models
{
    public class PastryContext : DbContext
    {
        public PastryContext(DbContextOptions<PastryContext> options) 
            : base(options)
        { 
            Database.EnsureCreated();
        }
        public DbSet<Pastry> pastries { get; set; }
    }
}
