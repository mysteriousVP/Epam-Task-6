using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(p => p.Products);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Provider);

            base.OnModelCreating(modelBuilder);
        }
    }
}
