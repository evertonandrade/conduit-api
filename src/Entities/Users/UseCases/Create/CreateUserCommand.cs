using Conduit.Api.Common.Abstractions;

namespace Conduit.Api.Entities.Users.UseCases.Create;

public record CreateUserCommand(UserName UserName, Email Email, string Password) : ICommand;
