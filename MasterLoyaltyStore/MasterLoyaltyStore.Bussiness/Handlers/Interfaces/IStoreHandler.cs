
using MasterLoyaltyStore.Entities.Models;

public interface IStoreHandler
{
    Task CreateStoreAsync(Store newStore, CancellationToken cancellationToken = default);
}