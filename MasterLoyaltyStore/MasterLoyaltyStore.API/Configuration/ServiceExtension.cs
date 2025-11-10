using MasterLoyaltyStore.Bussiness.Factories;
using MasterLoyaltyStore.Bussiness.Handlers;
using MasterLoyaltyStore.Bussiness.Handlers.Interfaces;
using MasterLoyaltyStore.Bussiness.Interfaces.Factories;
using MasterLoyaltyStore.Bussiness.Services;
using MasterLoyaltyStore.Bussiness.Services.Interface;
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
        services.AddScoped<IUserHandler, UserHandler>();
        //Repository
        services.AddScoped<IStoreRepository,StoreRepository>();
        services.AddScoped<IUserRepository,UserRepository>();
       services.AddScoped<IProductRepository,ProductRepository>();
        //Factorie pattern
        services.AddScoped<IUserCreationService, UserCreationService>();
        services.AddScoped<AdminFactory>();
        services.AddScoped<CustomerFactory>();
        
        
        //Generic Repository
        services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
        
        return services;
    }
}