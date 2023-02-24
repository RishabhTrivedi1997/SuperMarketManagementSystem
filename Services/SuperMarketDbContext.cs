using Microsoft.EntityFrameworkCore;
using SuperMarketManagementSystem.Models;

namespace SuperMarketManagementSystem.Services
{
    public class SuperMarketDbContext : DbContext
    {
        public SuperMarketDbContext(DbContextOptions<SuperMarketDbContext> options) : base(options)
        {
        }
        public DbSet<product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<seller> Sellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=POS;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

    }
}
