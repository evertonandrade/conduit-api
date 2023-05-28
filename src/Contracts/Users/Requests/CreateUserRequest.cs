namespace Conduit.Api.Contracts.Users.Requests;

public record CreateUserRequest(string Username, string Email, string Password);
