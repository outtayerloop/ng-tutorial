using Microsoft.EntityFrameworkCore;
using MyStore.Core.Database.Configuration;
using MyStore.Core.Domain.Model;

namespace MyStore.Core.Database
{
    public class MyStoreDbContext : DbContext
    {
        public MyStoreDbContext(DbContextOptions<MyStoreDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Shipping> Shippings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var productConfiguration = new ProductConfiguration(modelBuilder);
            productConfiguration.Configure();

            var shippingConfiguration = new ShippingConfiguration(modelBuilder);
            shippingConfiguration.Configure();
        }

        public int ClearAll()
        {
            Products.RemoveRange(Products);
            Shippings.RemoveRange(Shippings);
            return SaveChanges();
        }
    }
}
