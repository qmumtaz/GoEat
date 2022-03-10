using GoEat.Infrastructure.Context;
using GoEat.Infrastructure.Repository;
using GoEat.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoEat.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration) 
    {
        services.AddDbContext<OrderContext>();
        //services.AddDbContext<MenuContext>();
        var ConnectionString = configuration.GetRequiredSection("OrderContext:ConnectionString").Value;
        services.AddSingleton(new SqlServerSettings(ConnectionString));
        services.AddScoped<IOrderRepository, IOrderRepository>();

        return services;
    }
}
