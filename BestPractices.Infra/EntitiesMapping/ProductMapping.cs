using BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPractices.Infra.EntitiesMapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.ProductName).HasColumnType("varchar(255)")
                .HasColumnName("product_name").IsRequired();

            builder.Property(p => p.Price).HasColumnType("decimal(18,2)")
                .HasColumnName("price").IsRequired();

            builder.Property(p => p.Brand).HasColumnType("varchar(100)")
                .HasColumnName("brand").IsRequired();

            builder.Property(p => p.Category)
                .HasColumnName("category").IsRequired();

            builder.Property(p => p.Description).HasColumnType("varchar(max)")
                .HasColumnName("description").IsRequired();

            builder.Property(p => p.TransportationPrice).HasColumnType("decimal(18,2)")
                .HasColumnName("transportation_price").IsRequired();

            builder.HasOne(p => p.FileImage)
                .WithOne()
                .HasForeignKey<Product>(p => p.FileImageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
