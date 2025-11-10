using System.ComponentModel.DataAnnotations;
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
    
    
    
    //FullName
    public string FullName => $"{FirstName} {LastName}";
    
    //Relation
    public int UserTypeId { get; set; }
    public virtual UserType UserType { get; set; }
    
}