namespace BankTellerSystem.Domain.Interfaces.Infra;

public interface IUnitOfWork : IDisposable
{
    IClientRepository Clients { get; }
    IAccountRepository Accounts { get; }
    IAccountHistoryRepository AccountHistories { get; }
    Task BeginTransaction();
    Task<bool> CommitAsync();
    void Dispose();
}
