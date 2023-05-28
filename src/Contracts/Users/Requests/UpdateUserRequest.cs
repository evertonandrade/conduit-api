namespace Conduit.Api.Contracts.Users.Requests;

public record UpdateUserRequest(string Email, string Bio, string Image);