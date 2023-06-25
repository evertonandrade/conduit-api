using Conduit.Api.Common.Abstractions;
using Conduit.Api.Entities.Users;

namespace Conduit.Api.UseCases.Users.Commands.Create;

public record CreateUserCommand(UserName UserName, Email Email, string Password) : ICommand<User>;
