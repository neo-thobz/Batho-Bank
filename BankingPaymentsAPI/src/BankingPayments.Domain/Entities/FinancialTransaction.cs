using BankingPayments.Domain.Enums;

namespace BankingPayments.Domain.Entities;

public class FinancialTransaction
{
    public Guid Id { get; set; }

    public Guid PaymentId { get; set; }

    public Guid AccountId { get; set; }

    public TransactionEntryType EntryType { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "ZAR";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}