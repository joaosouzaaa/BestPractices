using BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPractices.Infra.EntitiesMapping
{
    public class FileImageMapping : IEntityTypeConfiguration<FileImage>
    {
        public void Configure(EntityTypeBuilder<FileImage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(f => f.ImageBytes).HasColumnType("varbinary(max)")
                .HasColumnName("image_bytes").IsRequired();

            builder.Property(f => f.FileName).HasColumnType("varchar(255)")
                .HasColumnName("file_name").IsRequired();

            builder.Property(f => f.FileExtension).HasColumnType("varchar(50)")
                .HasColumnName("file_extension").IsRequired();
        }
    }
}
