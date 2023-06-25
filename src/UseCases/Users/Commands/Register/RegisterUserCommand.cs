using Conduit.Api.Common.Abstractions;
using Conduit.Api.Entities.Users;
using Conduit.Api.UseCases.Users.Contracts;

namespace Conduit.Api.UseCases.Users.Commands.Register;

public record RegisterUserCommand(UserName UserName, Email Email, string Password) : ICommand<AuthenticationResponse>;
