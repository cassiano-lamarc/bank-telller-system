using BankTellerSystem.Domain.Entities;
using BankTellerSystem.Domain.Interfaces.Infra;
using BankTellerSystem.InfraData.Contexts;

namespace BankTellerSystem.InfraData.Reposiories;

public class AccountHistoryRepository : BaseRepository<AccountHistory>, IAccountHistoryRepository
{
    public AccountHistoryRepository(BankContext context) : base(context)
    {
    }
}
