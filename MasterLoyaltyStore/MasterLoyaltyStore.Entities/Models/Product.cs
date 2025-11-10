using System.ComponentModel.DataAnnotations;

namespace MasterLoyaltyStore.Entities.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool Status { get; set; } = true;

    //Relations
    public int IdStore { get; set; }
    
    
    //Navigations 
    public virtual Store IdStoreNavigation { get; set; }
    

}