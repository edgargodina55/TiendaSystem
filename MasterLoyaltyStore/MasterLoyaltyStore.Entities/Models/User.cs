using MasterLoyaltyStore.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace MasterLoyaltyStore.Entities.Models;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    public bool Status { get; set; } = true;
    public UserType UserType { get; set; }
    
    
    //FullName
    public string FullName => $"{FirstName} {LastName}";
}