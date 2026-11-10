using Microsoft.EntityFrameworkCore;
using BankingPayments.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingPayments.Infrastructure.Configurations;

public class FinancialTransactionConfiguration : IEntityTypeConfiguration<FinancialTransaction>
{
    public void Configure(
        EntityTypeBuilder<FinancialTransaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Amount)
            .HasPrecision(19, 4);

        builder.Property(t => t.Currency)
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(t => t.EntryType)
            .HasConversion<string>()
            .HasMaxLength(10);

        builder.HasOne<Payment>()
            .WithMany()
            .HasForeignKey(t => t.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Account>()
            .WithMany()
            .HasForeignKey(t => t.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(t => new
        {
            t.PaymentId,
            t.AccountId,
            t.EntryType
        }).IsUnique();

        builder.HasIndex(t => new
        {
            t.AccountId,
            t.CreatedAt
        });
    }
}