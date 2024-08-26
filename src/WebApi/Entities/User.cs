namespace Conduit.Entities;

public class User
{
    public long Id { get; init;  }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public Profile? Profile { get; init; }
}

public class Profile
{
    public required string Username { get; init; }
    public string? Bio { get; set; }
    public string? ImageUrl { get; set; }
}
