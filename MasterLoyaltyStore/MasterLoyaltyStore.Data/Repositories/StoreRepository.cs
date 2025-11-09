using MasterLoyaltyStore.Data.Context;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;

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
}