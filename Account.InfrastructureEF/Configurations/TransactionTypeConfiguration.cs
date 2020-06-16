using Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.InfrastructureEF
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.HasKey(_ => _.TransactionTypeId);
            builder.Property(_ => _.TransactionTypeName).IsRequired().HasMaxLength(30);

            builder.HasData(GetData());
        }

        private TransactionType[] GetData() 
        {
            return new TransactionType[]
            {
                new TransactionType() { TransactionTypeId = 1, TransactionTypeName = "Deposit" },
                new TransactionType() { TransactionTypeId = 2, TransactionTypeName = "Withdraw" },
                new TransactionType() { TransactionTypeId = 3, TransactionTypeName = "Transfer Money" }
            };
        }
    }
}
