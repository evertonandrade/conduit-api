namespace Conduit.Api.UseCases.Users.Contracts;

public record AuthenticationResponse(Guid Id, string Username, string Email, string Token);
