using Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Account.InfrastructureEF
{
    public class PeopleConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(_ => _.PersonId);
            builder.Property(_ => _.IdentificationTypeId).IsRequired();
            builder.Property(_ => _.IdentificationNumber).IsRequired().HasMaxLength(15);
            builder.Property(_ => _.FirstName).IsRequired().HasMaxLength(60);
            builder.Property(_ => _.LastName).IsRequired().HasMaxLength(60);
            builder.Property(_ => _.StatusId).IsRequired().HasDefaultValue(true);

            builder.HasOne(s => s.Status)
                .WithMany()
                .HasForeignKey(f => f.StatusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.IdentificationType)
                .WithMany()
                .HasForeignKey(f => f.IdentificationTypeId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
