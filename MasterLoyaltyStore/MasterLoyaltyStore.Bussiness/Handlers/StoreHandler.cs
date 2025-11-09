using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Handlers;

public class StoreHandler : IStoreHandler
{
    
    private readonly IStoreRepository _storeRepository;
    
    
    
    public async Task CreateStoreAsync(Store newStore, CancellationToken cancellationToken = default)
    {
        //Validaciones de datos
        await _storeRepository.AddAsync(newStore, cancellationToken);
        await _storeRepository.SaveChangesAsync(cancellationToken);
    }
    
    
    
}