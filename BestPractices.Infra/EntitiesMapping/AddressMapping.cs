using BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPractices.Infra.EntitiesMapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(a => a.ZipCode).HasColumnType("varchar(8)")
                .HasColumnName("zip_code").IsRequired();

            builder.Property(a => a.City).HasColumnType("varchar(80)")
                .HasColumnName("city").IsRequired();

            builder.Property(a => a.Street).HasColumnType("varchar(100)")
                .HasColumnName("street").IsRequired();

            builder.Property(a => a.State).HasColumnType("char(2)")
                .HasColumnName("state").IsRequired();

            builder.Property(a => a.Number).HasColumnType("varchar(10)")
                .HasColumnName("number").IsRequired();

            builder.Property(a => a.Complement).HasColumnType("varchar(100)")
                .HasColumnName("complement").IsRequired(false);
        }
    }
}
