using GoEat.Logic.Order.Factories;
using GoEat.Logic.Order.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GoEat.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddOrderItemValidator>());
        services.AddScoped<IOrderFactory, OrderFactory>();
        services.AddScoped<IDeliveryCalculator, DelieveryCalculator>();

       
        return services;
    }
}
