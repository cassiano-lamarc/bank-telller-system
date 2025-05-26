
using BankTellerSystem.Domain.Interfaces.Infra;
using BankTellerSystem.InfraData.Reposiories;
using BankTellerSystem.InfraData.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BankTellerSystem.InfraData.Configurations;

public static class RepositoriesConfigurations
{
    public static IServiceCollection AddRepositoriesConfigurations(this IServiceCollection services)
        => services.AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IAccountHistoryRepository, AccountHistoryRepository>()
            .AddScoped<IAccountRepository, AccountRepository>()
            .AddScoped<IClientRepository, ClientRepository>()
            .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
}
