using MasterLoyaltyStore.Data.Context;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterLoyaltyStore.Data.Repositories;

public class UserRepository :GenericRepository<User>, IUserRepository
{
    public UserRepository(StoreDbContext context) : base(context)
    {
    }

    public async Task<User> ExistsUser(string username)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.Equals(username) && x.Status);
    }
}