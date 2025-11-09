namespace MasterLoyaltyStore.API.Dtos.User;

public record class UserDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Role { get; init; }
}