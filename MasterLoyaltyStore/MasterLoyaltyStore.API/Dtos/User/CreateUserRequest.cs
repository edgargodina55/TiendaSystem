using MasterLoyaltyStore.Entities.Enums;

namespace MasterLoyaltyStore.API.Dtos.User;

public record CreateUserRequest()
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int UserTypeId { get; init; }
    public string Email { get; init; }
    public string Address { get; init; }
    public string Password { get; init; }
}