using Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.InfrastructureEF
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(_ => _.CurrencyId);
            builder.Property(_ => _.CurrencyName).IsRequired().HasMaxLength(30);
            builder.Property(_ => _.Code).IsRequired(false).HasMaxLength(6);
            builder.Property(_ => _.Symbol).IsRequired(false).HasMaxLength(2);

            builder.HasData(GetData());
        }

        private Currency[] GetData()
        {
            return new Currency[]
            {
                new Currency(){ CurrencyId = 1, CurrencyName = "Euros", Code = "EUR", Symbol = "€" }
            };
        }
    }
}
