using Conduit.Api.Entities.Users;

namespace Conduit.Api.Entities.Comments;

public class Comment
{
    public CommentId Id { get; } = Guid.NewGuid();
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    public required string Body { get; init; }
    public User Author { get; } = null!;
}
