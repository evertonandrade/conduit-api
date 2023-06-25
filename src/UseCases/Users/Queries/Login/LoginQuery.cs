using Conduit.Api.Common.Abstractions;
using Conduit.Api.Entities.Users;
using Conduit.Api.UseCases.Users.Contracts;

namespace Conduit.Api.UseCases.Users.Queries.Login;

public record LoginQuery(Email Email, string Password) : IQuery<AuthenticationResponse>;
