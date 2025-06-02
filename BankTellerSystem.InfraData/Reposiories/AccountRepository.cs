using BankTellerSystem.Domain.Entities;
using BankTellerSystem.Domain.Interfaces.Infra;
using BankTellerSystem.InfraData.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankTellerSystem.InfraData.Reposiories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(BankContext context) : base(context)
    {
    }

    public IQueryable FilterAccount(string? clientName, string? clientDoc)
        => _dbSet
        .Where(a => 
        (string.IsNullOrEmpty(clientName) || a.Client.Name.Contains(clientName)) &&
        (string.IsNullOrEmpty(clientDoc) || a.Client.Doc.Contains(clientDoc)))
        .AsQueryable();

    public async Task<Account?> FilterByDoc(string clientDoc)
        => await _dbSet
        .Where(a => a.Client.Doc == clientDoc)
        .FirstOrDefaultAsync();
}
