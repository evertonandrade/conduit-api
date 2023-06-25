namespace Conduit.Api.Entities.Users;

public class User
{
    public UserId Id { get; } = Guid.NewGuid();
    public required UserName UserName { get; init; }
    public required Email Email { get; init; }
    public required string Password { get; init; }
    public string? Bio { get; init; }
    public string? ImageUrl { get; init; }
}
