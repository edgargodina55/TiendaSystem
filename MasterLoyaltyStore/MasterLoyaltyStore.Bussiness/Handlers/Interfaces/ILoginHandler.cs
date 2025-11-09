using MasterLoyaltyStore.API.Dtos.Login;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Handlers.Interfaces;

public interface ILoginHandler
{
    
    Task<bool> RegisterUser(string firstName, string lastName, string email, string password,int userTypeId);
    Task<LoginResponse> Authenticate(string username, string password);
    
    
}