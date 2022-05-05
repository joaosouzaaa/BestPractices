using BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPractices.Infra.EntitiesMapping
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Name).HasColumnType("varchar(255)")
                .HasColumnName("name").IsRequired();

            builder.Property(c => c.LastName).HasColumnType("varchar(255)")
                .HasColumnName("last_name").IsRequired();

            builder.Property(c => c.BirthDate).HasColumnType("date")
                .HasColumnName("birth_date").IsRequired();

            builder.Property(c => c.Age).HasColumnType("int")
                .HasColumnName("age").IsRequired();

            builder.Property(c => c.CPF).HasColumnType("varchar(11)")
                .HasColumnName("cpf").IsRequired();
        }
    }
}
