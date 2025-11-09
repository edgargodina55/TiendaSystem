namespace MasterLoyaltyStore.API.Dtos.Login;

public record class LoginRequest
{
    public string Email { get; init; }
    public string Password { get; init; }
}