using BankTellerSystem.Domain.Interfaces.Infra;
using BankTellerSystem.InfraData.Contexts;

namespace BankTellerSystem.InfraData.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BankContext _context;

    public UnitOfWork(BankContext context)
    {
        _context = context;
    }

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}