using Microsoft.EntityFrameworkCore;
using MyStore.Core.Data.Entity.Model;

namespace MyStore.Core.Data.Context.Configuration
{
    public class ProductConfiguration : BaseConfiguration
    {
        public ProductConfiguration(ModelBuilder modelBuilder) : base(modelBuilder) { }

        public override void Configure()
        {
            _modelBuilder.Entity<Product>()
                .ToTable("PRODUCT")
                .HasKey(p => p.Id);

            _modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .IsRequired(true);

            _modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR(255)")
                .IsRequired(true);

            _modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            _modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("TEXT")
                .IsRequired(false);

            _modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnName("PRICE")
                .HasColumnType("DECIMAL")
                .IsRequired(true);
        }
    }
}
