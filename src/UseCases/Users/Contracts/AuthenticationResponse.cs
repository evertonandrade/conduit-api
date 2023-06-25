using Conduit.Api.Entities.Users;

namespace Conduit.Api.UseCases.Users.Contracts;

public record AuthenticationResponse(UserId Id, UserName Username, Email Email, string Token);
