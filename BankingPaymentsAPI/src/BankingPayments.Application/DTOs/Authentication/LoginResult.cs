namespace BankingPayments.Application.DTOs.Authentication;

public class LoginResult
{
    public string AccessToken { get; set; } = string.Empty;

    public DateTime ExpiresAtUtc { get; set; }
}