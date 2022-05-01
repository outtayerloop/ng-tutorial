using Microsoft.EntityFrameworkCore;
using MyStore.Core.Database.Configuration;
using MyStore.Core.Domain;

namespace MyStore.Core.Database
{
    public class MyStoreDbContext : DbContext
    {
        public MyStoreDbContext(DbContextOptions<MyStoreDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var productConfiguration = new ProductConfiguration(modelBuilder);
            productConfiguration.Configure();
        }
    }
}
