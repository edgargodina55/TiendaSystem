using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Handlers.Interfaces;

public interface IUserHandler
{
    Task<IEnumerable<User>> GetUsers();
    Task<User?> GetUserById(int id);
    Task<User> CreateUserAsync(User newUser,CancellationToken cancellationToken = default);
    Task<User> UpdateUserAsync(User updatedUser, CancellationToken cancellationToken = default);
    Task<User> DeleteUserAsync(int id,CancellationToken cancellationToken = default);
}