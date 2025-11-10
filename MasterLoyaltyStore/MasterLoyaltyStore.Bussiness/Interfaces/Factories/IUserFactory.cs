using MasterLoyaltyStore.Entities.Enums;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Interfaces.Factories;

public interface IUserFactory
{
    User CreateUser(string email, string password,string address,string firstName, string lastName,int userType);
}