using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Handlers.Interfaces;

public interface ICartHandler
{
    Task<Cart> CreateCartAsync();
}