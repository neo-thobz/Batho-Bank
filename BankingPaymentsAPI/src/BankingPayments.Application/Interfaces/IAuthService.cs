using BankingPayments.Application.DTOs.Authentication;

namespace BankingPayments.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResult?> LoginAsync(
        string email,
        string password);
}