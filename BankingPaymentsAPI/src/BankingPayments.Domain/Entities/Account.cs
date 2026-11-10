namespace BankingPayments.Domain.Entities;

public class Account
{
    public Guid Id { get; set; }

    public string AccountNumber { get; set; } = string.Empty;

    public string OwnerId { get; set; } = string.Empty;

    public decimal Balance { get; set; }

    public string Currency { get; set; } = "ZAR";

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}