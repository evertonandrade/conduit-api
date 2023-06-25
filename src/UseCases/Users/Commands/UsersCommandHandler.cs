using Conduit.Api.Common.Abstractions;
using Conduit.Api.Database;
using Conduit.Api.Entities.Users;
using Conduit.Api.UseCases.Users.Commands.Create;
using Conduit.Api.UseCases.Users.Commands.Update;

namespace Conduit.Api.UseCases.Users.Commands;

public class UsersCommandHandler : ICommandHandler<CreateUserCommand, User>,
        ICommandHandler<UpdateUserCommand, User>
{
    private readonly ApplicationDbContext _dbContext;

    public UsersCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User { Email = command.Email, UserName = command.UserName };
        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
