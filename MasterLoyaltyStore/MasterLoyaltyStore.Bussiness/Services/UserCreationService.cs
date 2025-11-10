using MasterLoyaltyStore.Bussiness.Factories;
using MasterLoyaltyStore.Bussiness.Interfaces.Factories;
using MasterLoyaltyStore.Bussiness.Services.Interface;
using MasterLoyaltyStore.Entities.Enums;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Services;

public class UserCreationService : IUserCreationService
{
    private readonly AdminFactory _adminFactory;
    private readonly CustomerFactory _customerFactory;


    public UserCreationService(AdminFactory adminFactory, CustomerFactory customerFactory)
    {
        _adminFactory = adminFactory;
        _customerFactory = customerFactory;
    }

    public User CreateUser(string email, string password,string address, string firstName, string lastName, int userType)
    {
        IUserFactory factory = userType switch
        {
            (int)UserTypeId.Admin => new AdminFactory(),
            (int)UserTypeId.Customer => new CustomerFactory(),
            _ => throw new ArgumentException("Invalid user type")
        };
            
            return factory.CreateUser(email, password,address, firstName, lastName, userType);
    }
}