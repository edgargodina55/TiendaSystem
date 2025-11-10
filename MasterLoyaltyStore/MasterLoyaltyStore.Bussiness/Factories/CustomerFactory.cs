using MasterLoyaltyStore.Bussiness.Interfaces.Factories;
using MasterLoyaltyStore.Entities.Enums;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Factories;

public class CustomerFactory : IUserFactory
{
    public User CreateUser(string email, string password,string address, string firstName, string lastName, int userType)
    {
        return new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            UserName = email,
            Address = address,
            PasswordHash = password,
            UserTypeId = (int)UserTypeId.Customer
        };
    }
}