namespace Conduit.Api.Entities.Comments;

public readonly record struct CommentId(Guid Value)
{
    public static implicit operator Guid(CommentId id) => id.Value;
    public static implicit operator CommentId(Guid value) => new(value);
}