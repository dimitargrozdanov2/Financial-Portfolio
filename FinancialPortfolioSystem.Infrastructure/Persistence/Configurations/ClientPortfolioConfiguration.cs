using FinancialPortfolioSystem.Application.Features;
using FinancialPortfolioSystem.Domain.Models.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Configurations
{
    internal class ClientPortfolioConfiguration : IEntityTypeConfiguration<ClientPortfolio>
    {
        public void Configure(EntityTypeBuilder<ClientPortfolio> builder)
        {
            builder
                .HasKey(cp => cp.Id);

            builder
                .Property(ct => ct.ClientId)
                .IsRequired();

            builder
                .HasMany(ct => ct.ClientAssets)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("clientAssets");

            builder
                .HasMany(ct => ct.Transactions)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("transactions");
        }
    }
}
