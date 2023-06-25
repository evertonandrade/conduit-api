using Conduit.Api.Common.Abstractions;
using Conduit.Api.Entities.Users;

namespace Conduit.Api.UseCases.Users.Commands.Update;

public record UpdateUserCommand(UserId UserId, Email Email, string Bio, string ImageUrl)
    : ICommand<User>;
