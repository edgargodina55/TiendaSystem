using MasterLoyaltyStore.Data.Context;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterLoyaltyStore.Data.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(StoreDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsByStore(int storeId)
    {
        return await _dbSet.AsNoTracking()
            .Where(x => x.Status && x.IdStore == storeId && x.Stock > 0)
            .ToListAsync();
    }
}