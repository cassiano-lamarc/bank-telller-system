using BankTellerSystem.InfraData.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankTellerSystem.InfraData.Configurations;

public static class AddContextConfiguration
{
    public static IServiceCollection AddContextConfigurations(this IServiceCollection services)
        => services.AddDbContext<BankContext>(options =>
            options.UseInMemoryDatabase("BankDbInMemory"));
}
