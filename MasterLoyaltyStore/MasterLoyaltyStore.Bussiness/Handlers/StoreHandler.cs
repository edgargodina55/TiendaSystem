using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.Extensions.Logging;

namespace MasterLoyaltyStore.Bussiness.Handlers;

public class StoreHandler : IStoreHandler
{
    
    private readonly IStoreRepository _storeRepository;
    private ILogger<StoreHandler> _logger;

    public StoreHandler(ILogger<StoreHandler> logger, IStoreRepository storeRepository)
    {
        _logger = logger;
        _storeRepository = storeRepository;
    }

    public async Task<Store?> GetStoreById(int storeId)
    {
        return await _storeRepository.GetByIdAsync(storeId);
    }

    public async Task<IEnumerable<Store>> GetStores()
    {
        return await _storeRepository.GetAllStores();
    }

    public async Task CreateStoreAsync(Store newStore, CancellationToken cancellationToken = default)
    {
        //Validaciones de datos
        await _storeRepository.AddAsync(newStore, cancellationToken);
        await _storeRepository.SaveChangesAsync(cancellationToken);
    }
    
    
    
}