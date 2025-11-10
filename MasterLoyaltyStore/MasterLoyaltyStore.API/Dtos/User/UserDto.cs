namespace MasterLoyaltyStore.API.Dtos.User;

public record class UserDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string LastName { get; init; }
    public string FullName => $"{Name} {LastName}";
    public string Adress { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public int RoleId { get; init; }
    public string RoleName { get; init; }
}