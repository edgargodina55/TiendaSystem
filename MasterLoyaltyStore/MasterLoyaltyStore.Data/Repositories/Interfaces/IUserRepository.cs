using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Data.Repositories.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> ExistsUser(string username);
    Task<User> FindUserByCredentials(string username,string hashedPassword);
}