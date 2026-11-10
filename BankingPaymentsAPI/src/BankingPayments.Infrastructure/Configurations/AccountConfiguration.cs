using Microsoft.EntityFrameworkCore;
using BankingPayments.Domain.Entities;
using BankingPayments.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingPayments.Infrastructure.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.AccountNumber)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(a => a.AccountNumber)
            .IsUnique();

        builder.Property(a => a.Balance)
            .HasPrecision(19, 4);

        builder.Property(a => a.Currency)
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(a => a.OwnerId)
            .IsRequired();

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(a => a.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }   
}