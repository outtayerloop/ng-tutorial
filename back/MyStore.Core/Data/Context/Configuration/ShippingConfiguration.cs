using Microsoft.EntityFrameworkCore;
using MyStore.Core.Data.Entity.Model;

namespace MyStore.Core.Data.Context.Configuration
{
    public class ShippingConfiguration : BaseConfiguration
    {
        public ShippingConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Configure()
        {
            _modelBuilder.Entity<Shipping>()
                .ToTable("SHIPPING")
                .HasKey(s => s.Id);

            _modelBuilder.Entity<Shipping>()
                .Property(s => s.Id)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .IsRequired(true);

            _modelBuilder.Entity<Shipping>()
                .Property(s => s.Package)
                .HasColumnName("PACKAGE")
                .HasColumnType("INTEGER")
                .HasConversion<int>()
                .IsRequired(true);

            _modelBuilder.Entity<Shipping>()
                .HasIndex(s => s.Package)
                .IsUnique();

            _modelBuilder.Entity<Shipping>()
                .Property(s => s.Price)
                .HasColumnName("PRICE")
                .HasColumnType("DECIMAL")
                .IsRequired(true);
        }
    }
}
