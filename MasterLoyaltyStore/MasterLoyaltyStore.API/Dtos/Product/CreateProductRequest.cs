namespace MasterLoyaltyStore.API.Dtos.Product;

public record class CreateProductRequest
{
    public string Name{get;init;}
    public string Code{get;init;}
    public string Description{get;init;}
    public string ImageUrl { get; init; }
    public int Stock { get; init; }
    public int IdStore { get; init; }
    public bool? Status { get; init; } = true;
    public int? IdStoreNavigationStoreId { get; set; }

}