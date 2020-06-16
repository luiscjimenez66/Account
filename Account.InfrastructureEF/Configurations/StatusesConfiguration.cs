using Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.InfrastructureEF
{
    public class StatusesConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(_ => _.StatusId);
            builder.Property(_ => _.StatusId).IsRequired();
            builder.Property(_ => _.StatusName).IsRequired().HasMaxLength(30);

            builder.HasData(GetData());
        }

        private Status[] GetData() 
        {
            return new Status[]
            {
                new Status() { StatusId = 1, StatusName = "Active" },
                new Status() { StatusId = 2, StatusName = "Inactive" }
            };
        }
    }
}
