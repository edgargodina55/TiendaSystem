
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.API.Dtos.Login;

public class LoginResponse
{
    public User? User { get; set; }
    public string? Token { get; set; }
}