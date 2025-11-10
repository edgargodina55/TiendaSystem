using MasterLoyaltyStore.API.Dtos.Product;

namespace MasterLoyaltyStore.API.Dtos.Store;

public record class StoreDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Address { get; init; }
    public bool Status { get; init; }

    public List<ProductDto> Products { get; init; }
}