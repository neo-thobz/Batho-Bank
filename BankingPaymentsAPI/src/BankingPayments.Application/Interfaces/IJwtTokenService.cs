using BankingPayments.Application.DTOs.Authentication;

namespace BankingPayments.Application.Interfaces;

public interface IJwtTokenService
{
    Task<JwtTokenResult> GenerateTokenAsync(
        string userId,
        string email);
}