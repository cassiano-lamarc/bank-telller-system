using BankTellerSystem.Domain.Interfaces.Infra;
using BankTellerSystem.InfraData.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankTellerSystem.InfraData.Reposiories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly BankContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(BankContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        var newEntity = await _dbSet.AddAsync(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
