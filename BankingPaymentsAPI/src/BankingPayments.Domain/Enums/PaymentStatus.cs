namespace BankingPayments.Domain.Enums;

public enum PaymentStatus
{
    Draft = 1,
    PendingApproval = 2,
    Approved = 3,
    Rejected = 4
}