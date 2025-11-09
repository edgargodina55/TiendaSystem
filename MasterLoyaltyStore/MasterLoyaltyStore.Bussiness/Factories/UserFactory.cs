using MasterLoyaltyStore.Bussiness.Interfaces.Factories;
using MasterLoyaltyStore.Entities.Enums;

namespace MasterLoyaltyStore.Bussiness.Factories;

public class UserFactory : IUserFactory
{
    
    
    public Task CreateUserAsync(string email, string password, string firstName, string lastName, UserType userType)
    {
        throw new NotImplementedException();
    }
}