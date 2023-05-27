namespace Conduit.Api.Entities.Articles;

public class Article
{
    public string? Slug { get; private set; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string Body { get; init; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    public bool Favorited { get; private set; }
    public int FavoritedCount { get; private set; }
}