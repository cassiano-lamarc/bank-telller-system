using BankTellerSystem.Domain.Entities;

namespace BankTellerSystem.Domain.Interfaces.Infra;

public interface IAccountRepository : IBaseRepository<Account>
{
    public IQueryable FilterAccount(string? clientName, string? clientDoc);
    Task<Account?> FilterByDoc(string clientDoc);
}
