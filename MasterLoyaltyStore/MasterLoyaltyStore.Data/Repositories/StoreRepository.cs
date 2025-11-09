using System.Linq.Expressions;
using MasterLoyaltyStore.Data.Context;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Data.Repositories;

public class StoreRepository : GenericRepository<Store>,IStoreRepository
{
    public StoreRepository(StoreDbContext context) : base(context)
    {
    }
}