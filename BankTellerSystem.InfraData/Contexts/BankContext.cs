using BankTellerSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankTellerSystem.InfraData.Contexts;

public class BankContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<AccountHistory> AccountHistories { get; set; }

    public BankContext(DbContextOptions<BankContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
