namespace MasterLoyaltyStore.Entities.Models;

public class Store
{
    public int IdStore { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public bool Status { get; set; } = true;

    //Navigation
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}