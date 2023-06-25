namespace Conduit.Api.UseCases.Users.Contracts;

public record RegisterRequest(string Username, string Email, string Password);
