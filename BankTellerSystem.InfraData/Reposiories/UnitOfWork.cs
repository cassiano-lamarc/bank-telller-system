using BankTellerSystem.Domain.Interfaces.Infra;
using BankTellerSystem.InfraData.Contexts;
using BankTellerSystem.InfraData.Reposiories;
using Microsoft.EntityFrameworkCore.Storage;

namespace BankTellerSystem.InfraData.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(BankContext context)
    {
        _context = context;
        Clients = new ClientRepository(context);
        Accounts = new AccountRepository(context);
        AccountHistories = new AccountHistoryRepository(context);
    }

    private readonly BankContext _context;
    private IDbContextTransaction _transaction;
    public IClientRepository Clients { get; }
    public IAccountRepository Accounts { get; }
    public IAccountHistoryRepository AccountHistories { get; }

    public async Task BeginTransaction()
    {
        if (_transaction == null)
            _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task<bool> CommitAsync()
    {
        int rowsAffected = 0;
        try
        {
            rowsAffected = await _context.SaveChangesAsync();
            if (_transaction != null)
                await _transaction.CommitAsync();
        }
        catch
        {
            await RollbackAsync();
        }
        finally
        {
            await DisposeTransactionAsync();
        }

        return rowsAffected > 0;
    }

    private async Task DisposeTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await DisposeTransactionAsync();
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}