using BankTellerSystem.Domain.Entities;
using BankTellerSystem.Domain.Interfaces.Infra;
using BankTellerSystem.InfraData.Contexts;

namespace BankTellerSystem.InfraData.Reposiories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(BankContext context) : base(context)
    {
    }
}
