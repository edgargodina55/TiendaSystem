using System.ComponentModel.DataAnnotations;

namespace MasterLoyaltyStore.Entities.Models;

public class Cart
{
    [Key]
    public int CartId { get; set; }
    
    //Usuario
    public int UserId { get; set; }
    public virtual User User { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}