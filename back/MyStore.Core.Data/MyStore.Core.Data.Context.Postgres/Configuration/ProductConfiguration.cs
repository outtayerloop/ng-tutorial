using Microsoft.EntityFrameworkCore;
using MyStore.Core.Data.Entity.Constants;
using MyStore.Core.Data.Entity.Relation;

namespace MyStore.Core.Data.Context.Postgres
{
    internal class ProductConfiguration : BaseConfiguration
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
                .HasMaxLength(ProductConstants.MaxNameLenth)
                .IsRequired(true);

            _modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            _modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(ProductConstants.MaxDescriptionLenth)
                .IsRequired(false);

            _modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnName("PRICE")
                .HasColumnType("DECIMAL")
                .IsRequired(true);

            _modelBuilder.Entity<Product>()
                .HasCheckConstraint(
                    "CHK_PRODUCT_PRICE", 
                    $"\"PRICE\" >= {ProductConstants.MinPrice} AND \"PRICE\" <= {ProductConstants.MaxPrice}",
                    c => c.HasName("CHK_PRODUCT_PRICE")
                );
        }
    }
}
