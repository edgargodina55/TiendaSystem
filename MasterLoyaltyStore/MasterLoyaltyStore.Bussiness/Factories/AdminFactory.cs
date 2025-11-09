using MasterLoyaltyStore.Bussiness.Interfaces.Factories;
using MasterLoyaltyStore.Entities.Enums;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Factories;

public class AdminFactory : IUserFactory
{
    
    public User CreateUserAsync(string email, string password, string firstName, string lastName, int userType)
    {
        return new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PasswordHash = password,
            UserTypeId = (int)UserTypeId.Admin
        };
    }
}