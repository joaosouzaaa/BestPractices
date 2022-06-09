using BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPractices.Infra.EntitiesMapping
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(s => s.CNPJ).HasColumnType("varchar(14)")
                .HasColumnName("cnpj").IsRequired();

            builder.Property(s => s.CompanyName).HasColumnType("varchar(255)")
                .HasColumnName("company_name").IsRequired();

            builder.HasOne(s => s.CompanyAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
