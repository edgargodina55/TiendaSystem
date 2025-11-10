using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Data.Repositories.Interfaces;

public interface IStoreRepository: IGenericRepository<Store>
{
    Task<Store> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<IEnumerable<Store>> GetAllStores();
}