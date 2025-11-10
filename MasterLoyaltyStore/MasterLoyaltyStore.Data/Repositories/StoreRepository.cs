using MasterLoyaltyStore.Data.Context;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterLoyaltyStore.Data.Repositories;

public class StoreRepository : GenericRepository<Store>, IStoreRepository
{
    public StoreRepository(StoreDbContext context) : base(context)
    {
    }

    public async Task<Store> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        
        return new Store();
    }

    public async Task<IEnumerable<Store>> GetAllStores()
    {
        return await _dbSet.AsNoTracking()
            .Include(x => x.Products)
            .Where(x => x.Status)
            .ToListAsync();
    }
}