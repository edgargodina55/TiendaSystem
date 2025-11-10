using MasterLoyaltyStore.Bussiness.Handlers;
using MasterLoyaltyStore.Bussiness.Handlers.Interfaces;
using MasterLoyaltyStore.Data.Repositories;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;


namespace MasterLoyaltyStore.API.Configuration;

public static class ServiceExtension
{


    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //Handlers
        services.AddSingleton<Utils>();
        services.AddScoped<ILoginHandler, LoginHandler>();
        services.AddScoped<IStoreHandler, StoreHandler>();
        services.AddScoped<IProductHandler, ProductHandler>();
        //Repository
        services.AddScoped<IStoreRepository,StoreRepository>();
        services.AddScoped<IUserRepository,UserRepository>();
       
        //Generic Repository
        services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
        
        return services;
    }
}