using Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.InfrastructureEF
{
    public class IdentificationTypesConfiguration : IEntityTypeConfiguration<IdentificationType>
    {
        public void Configure(EntityTypeBuilder<IdentificationType> builder)
        {
            builder.HasKey(_ => _.IdentificationTypeId);
            builder.Property(_ => _.IdentificationTypeId).IsRequired();
            builder.Property(_ => _.IdentificationTypeName).IsRequired().HasMaxLength(100);

            builder.HasData(GetData());
        }

        private IdentificationType[] GetData()
        {
            return new IdentificationType[]
            {
                new IdentificationType() { IdentificationTypeId = 1, IdentificationTypeName = "DNI" }
            };
        }
    }
}
