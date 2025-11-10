using System.ComponentModel.DataAnnotations;

namespace MasterLoyaltyStore.Entities.Models;

public class CartItem
{
    [Key]
    public int CartItemId { get; set; }

    // relación al carrito
    public int CartId { get; set; }
    public virtual Cart Cart { get; set; }

    // relación al producto
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    // datos del carrito
    public int Quantity { get; set; } = 1;
}