using MasterLoyaltyStore.Bussiness.Handlers.Interfaces;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Handlers;

public class ProductHandler : IProductHandler
{
    private readonly IGenericRepository<Product> _productRepository;


    public ProductHandler(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }


    public async Task<Product?> GetProductById(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productRepository.GetAllAsync();
    }


    public async Task<Product> CreateAsync(Product newProduct,CancellationToken cancellationToken = default)
    {
        await _productRepository.AddAsync(newProduct,cancellationToken);
        await _productRepository.SaveChangesAsync(cancellationToken);

        return newProduct;
    }
}