using BankTellerSystem.Domain.Entities;
using BankTellerSystem.Domain.Interfaces.Infra;
using BankTellerSystem.InfraData.Contexts;

namespace BankTellerSystem.InfraData.Reposiories;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    public ClientRepository(BankContext context) : base(context)
    {
    }
}