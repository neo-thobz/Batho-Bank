using Microsoft.AspNetCore.Identity;

namespace BankingPayments.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? DisplayName { get; set; }
}