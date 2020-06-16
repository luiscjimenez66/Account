using Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.InfrastructureEF
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.UserId);
            builder.Property(_ => _.UserName).IsRequired().HasMaxLength(30);
            builder.Property(_ => _.Password).IsRequired();
            builder.Property(_ => _.StatusId).IsRequired();
            builder.Property(_ => _.ModifiedAt).IsRequired(false);

            builder.HasOne(s => s.Status)
                .WithMany()
                .HasForeignKey(f => f.StatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
