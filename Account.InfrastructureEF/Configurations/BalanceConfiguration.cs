using Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.InfrastructureEF
{
    public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.HasKey(_ => _.BalanceId);
            builder.Property(_ => _.CurrencyId).IsRequired();
            builder.Property(_ => _.StatusId).IsRequired();
            builder.Property(_ => _.Amount).IsRequired().HasDefaultValue(0).HasColumnType("decimal(22,4)");
            builder.Property(_ => _.CreatedAt).IsRequired();
            builder.Property(_ => _.ModifiedAt).IsRequired(false);
            builder.Property(_ => _.ModifiedBy).IsRequired(false);

            builder.HasOne(_ => _.Currency)
                .WithMany()
                .HasForeignKey(_ => _.CurrencyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.Status)
                .WithMany()
                .HasForeignKey(_ => _.StatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
