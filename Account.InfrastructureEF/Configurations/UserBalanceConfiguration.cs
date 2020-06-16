using Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.InfrastructureEF
{
    public class UserBalanceConfiguration : IEntityTypeConfiguration<UserBalance>
    {
        public void Configure(EntityTypeBuilder<UserBalance> builder)
        {
            builder.HasKey(_ => new { _.UserId, _.BalanceId });
            builder.Property(_ => _.Principal).IsRequired().HasDefaultValue(false);
            builder.Property(_ => _.PermissionAdmin).IsRequired().HasDefaultValue(false);

            builder.HasOne(_ => _.User)
                .WithMany(m => m.UsersBalances)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.Balance)
                .WithMany(m => m.UsersBalances)
                .HasForeignKey(f => f.BalanceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
