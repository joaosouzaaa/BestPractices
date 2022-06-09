﻿using BestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPractices.Infra.EntitiesMapping
{
    public class ShoppingCartMapping : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(s => s.TotalItens).HasColumnType("int")
                .HasColumnName("total_itens").IsRequired();

            builder.Property(s => s.TotalAmount).HasColumnType("decimal(18,2)")
                .HasColumnName("total_amount").IsRequired();

            builder.HasMany(s => s.Products)
                .WithOne(p => p.ShoppingCart)
                .HasForeignKey(p => p.ShoppingCartId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
