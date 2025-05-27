using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BankTellerSystem.Application.Configurations;

public static class AddMediatRServices
{
    public static IServiceCollection AddMediatRAppServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(AddMediatRServices).Assembly);
        return services;
    }
}
