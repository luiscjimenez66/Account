using Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.InfrastructureEF
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(_ => _.TransactionId);
            builder.Property(_ => _.TransactionTypeId).IsRequired();
            builder.Property(_ => _.UserId).IsRequired(false);
            builder.Property(_ => _.BalanceId).IsRequired();
            builder.Property(_ => _.DestinationBalanceId).IsRequired(false);
            builder.Property(_ => _.Amount).IsRequired().HasColumnType("decimal(22, 4)");
            builder.Property(_ => _.CurrentAmount).IsRequired().HasColumnType("decimal(22, 4)");

            builder.Property(_ => _.CreateAt).IsRequired();

            builder.HasOne(_ => _.Balance)
                .WithMany(m => m.Transactions)
                .HasForeignKey(_ => _.BalanceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.DestinationBalance)
                .WithMany()
                .HasForeignKey(f => f.DestinationBalanceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
