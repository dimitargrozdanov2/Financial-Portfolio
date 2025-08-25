using FinancialPortfolioSystem.Domain.Models.Client;
using FinancialPortfolioSystem.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Email)
            .IsRequired();

        builder
            .HasOne(u => u.Portfolio)
            .WithOne()
            .HasForeignKey<ClientPortfolio>("UserId")
            .IsRequired();
    }
}
