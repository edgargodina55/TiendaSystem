using MasterLoyaltyStore.Entities.Enums;

namespace MasterLoyaltyStore.Bussiness.Interfaces.Factories;

public interface IUserFactory
{
    Task CreateUserAsync(string email, string password,string firstName, string lastName,UserType userType);
}