using Exchange.Application.Interfaces.Persistence;
using Exchange.Infrastracture.Persistence;
using Microsoft.Extensions.DependencyInjection;


namespace Exchange.Infrastracture;

public static class DependancyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {

        services.AddScoped<IExchangeRepository, ExchangeRepository>();

        return services;
    }

}
