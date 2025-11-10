using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Services.Interface;

public interface IUserCreationService
{
    User CreateUser(string email, string password,string address, string firstName, string lastName, int userType);
}