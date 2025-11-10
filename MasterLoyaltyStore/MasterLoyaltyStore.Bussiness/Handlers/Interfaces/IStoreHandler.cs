
using MasterLoyaltyStore.Entities.Models;

public interface IStoreHandler
{
    Task<Store?> GetStoreById(int storeId);
    
    Task<IEnumerable<Store>> GetStores();
    Task CreateStoreAsync(Store newStore, CancellationToken cancellationToken = default);
}