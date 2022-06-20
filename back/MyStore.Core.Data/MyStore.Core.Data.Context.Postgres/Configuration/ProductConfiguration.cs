using Microsoft.EntityFrameworkCore;
using MyStore.Core.Data.Entity.Relation;

namespace MyStore.Core.Data.Context.Postgres
{
    internal class ProductConfiguration : BaseConfiguration
    {
        private static readonly int _maxNameLength = 64;

        private static readonly int _maxDescriptionLength = 128;

        /// <summary>
        /// Minimum valid price for a product.
        /// </summary>
        private static readonly decimal _minPrice = 1M;

        /// <summary>
        /// Maximum valid price for a product.
        /// </summary>
        private static readonly decimal _maxPrice = 100_000M;

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
                .HasMaxLength(_maxNameLength)
                .IsRequired(true);

            _modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            _modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(_maxDescriptionLength)
                .IsRequired(false);

            _modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnName("PRICE")
                .HasColumnType("DECIMAL")
                .IsRequired(true);

            _modelBuilder.Entity<Product>()
                .HasCheckConstraint(
                    "CHK_PRODUCT_PRICE", 
                    $"\"PRICE\" >= {_minPrice} AND \"PRICE\" <= {_maxPrice}",
                    c => c.HasName("CHK_PRODUCT_PRICE")
                );
        }
    }
}
