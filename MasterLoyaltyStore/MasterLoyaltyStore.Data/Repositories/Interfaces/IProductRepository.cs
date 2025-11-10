using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Data.Repositories.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByStore(int storeId);
}