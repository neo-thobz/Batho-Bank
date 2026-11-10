using BankingPayments.Domain.Enums;

namespace BankingPayments.Domain.Entities;

public class Payment
{
    public decimal Amount { get; set; }

    public string Currency { get; set; } = "ZAR";

    public string Reference { get; set; } = string.Empty;

    public PaymentStatus Status { get; set; } = PaymentStatus.Draft;

    public string MakerId { get; set; } = string.Empty;

    public string? CheckerId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? SubmittedAt { get; set; }

    public DateTime? DecidedAt { get; set; }

    public string? RejectionReason { get; set; }
}