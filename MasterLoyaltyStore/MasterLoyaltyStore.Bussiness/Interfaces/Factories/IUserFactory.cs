using MasterLoyaltyStore.Entities.Enums;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Interfaces.Factories;

public interface IUserFactory
{
    User CreateUserAsync(string email, string password,string firstName, string lastName,int userType);
}