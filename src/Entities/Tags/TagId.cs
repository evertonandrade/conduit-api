namespace Conduit.Api.Entities.Tags;

public readonly record struct TagId(Guid Value)
{
    public static implicit operator Guid(TagId id) => id.Value;
    public static implicit operator TagId(Guid value) => new(value);
}