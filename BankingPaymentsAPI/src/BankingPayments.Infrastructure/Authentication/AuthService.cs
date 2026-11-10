using Microsoft.AspNetCore.Identity;
using BankingPayments.Application.Interfaces;
using BankingPayments.Infrastructure.Identity;
using BankingPayments.Application.DTOs.Authentication;

namespace BankingPayments.Infrastructure.Authentication;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtTokenService jwtTokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<LoginResult?> LoginAsync(
        string email,
        string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            return null;
        }

        var passwordResult = await _signInManager.CheckPasswordSignInAsync(
            user,
            password,
            lockoutOnFailure: true);

        if (!passwordResult.Succeeded)
        {
            return null;
        }

        var tokenResult = await _jwtTokenService.GenerateTokenAsync(
            user.Id,
            user.Email!);

        return new LoginResult
        {
            AccessToken = tokenResult.AccessToken,
            ExpiresAtUtc = tokenResult.ExpiresAtUtc
        };
    }
}