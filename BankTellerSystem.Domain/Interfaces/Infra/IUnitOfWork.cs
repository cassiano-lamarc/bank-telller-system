namespace BankTellerSystem.Domain.Interfaces.Infra;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
    void Dispose();
}
