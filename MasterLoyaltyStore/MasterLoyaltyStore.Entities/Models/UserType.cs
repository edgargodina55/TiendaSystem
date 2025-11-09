using MasterLoyaltyStore.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace MasterLoyaltyStore.Entities.Models;

public class UserType
{
    public int UserTypeId { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    
}