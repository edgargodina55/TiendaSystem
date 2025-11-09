using MasterLoyaltyStore.Bussiness.Handlers;
using MasterLoyaltyStore.Bussiness.Handlers.Interfaces;

namespace MasterLoyaltyStore.API.Configuration;

public static class ServiceExtension
{


    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //
        
        services.AddScoped<IStoreHandler, StoreHandler>();
        services.AddScoped<IProductHandler, ProductHandler>();
        
        
        return services;
    }
}