using Exchange.Application.Services;
using Exchange.Application.Services.Order;
using Microsoft.Extensions.DependencyInjection;


namespace Exchange.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        return services;
    }
}