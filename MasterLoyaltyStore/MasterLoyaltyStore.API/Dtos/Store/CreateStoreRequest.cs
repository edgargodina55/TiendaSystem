namespace MasterLoyaltyStore.API.Dtos.Store;

public record CreateStoreRequest()
{
    public string Name { get; init; }
    public string Address { get; init; }
    public bool Status { get; init; } = true;
}