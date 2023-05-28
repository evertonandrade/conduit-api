namespace Conduit.Api.Entities.Tags;

public class Tag
{
    public TagId Id { get; } = Guid.NewGuid();
    public required string Name { get; init; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
}