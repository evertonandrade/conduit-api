namespace Conduit.Api.Entities.Users;

public class User
{
    public UserId Id { get; } = Guid.NewGuid();
    public required UserName UserName { get; init; }
    public required Email Email { get; init; }
    public string? Bio { get; private set; }
    public string? ImageUrl { get; private set; }
}
