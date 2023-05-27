namespace Conduit.Api.Entities.Users;

public readonly record struct UserId(Guid Value)
{
    public static implicit operator Guid(UserId id) => id.Value;
    public static implicit operator UserId(Guid value) => new(value);
}