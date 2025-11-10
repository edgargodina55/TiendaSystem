using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Handlers.Interfaces;

public interface IProductHandler
{
    Task<Product?> GetProductById(int id);
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> CreateAsync(Product newProduct,CancellationToken cancellationToken);
      
}