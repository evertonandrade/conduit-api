namespace Conduit.Entities;

public sealed class User
{
    public long Id { get; }
    public required string Email { get; init; }
    public required string Password { get; set; }
    public Profile? Profile { get; set; }
}

public sealed class Profile
{
    public required string Username { get; init; }
    public string? Bio { get; set; }
    public string? ImageUrl { get; set; }
}
