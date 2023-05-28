using Conduit.Api.Common.Abstractions;

namespace Conduit.Api.Entities.Users.UseCases.Update;

public record UpdateUserCommand(Email Email, string Bio, string ImageUrl) : ICommand;
