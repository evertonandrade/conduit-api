using Conduit.Api.Common.Abstractions;
using Conduit.Api.Common.Authentication;
using Conduit.Api.Database;
using Conduit.Api.Entities.Users;
using Conduit.Api.UseCases.Users.Commands.Register;
using Conduit.Api.UseCases.Users.Contracts;

namespace Conduit.Api.UseCases.Users.Commands;

public class UsersCommandHandler : ICommandHandler<RegisterUserCommand, AuthenticationResponse>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public UsersCommandHandler(ApplicationDbContext dbContext, JwtTokenGenerator jwtTokenGenerator)
    {
        _dbContext = dbContext;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResponse> Handle(
        RegisterUserCommand command,
        CancellationToken cancellationToken
    )
    {
        if (_dbContext.Users.Any(user => user.Email == command.Email))
        {
            throw new ApplicationException("Duplicate Email"); // TODO: change to fluent results
        }
        var user = new User
        {
            Email = command.Email,
            UserName = command.UserName,
            Password = command.Password
        };
        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResponse(user.Id, user.UserName, user.Email, token);
    }
}
