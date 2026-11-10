using Microsoft.EntityFrameworkCore;
using BankingPayments.Domain.Entities;
using BankingPayments.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BankingPayments.Infrastructure.Persistence;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
{
    public DbSet<Account> Accounts => Set<Account>();

    public DbSet<Payment> Payments => Set<Payment>();

    public DbSet<FinancialTransaction> FinancialTransactions => Set<FinancialTransaction>();
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}