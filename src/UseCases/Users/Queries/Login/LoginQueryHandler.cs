using Conduit.Api.Common.Abstractions;
using Conduit.Api.Common.Authentication;
using Conduit.Api.Database;
using Conduit.Api.UseCases.Users.Contracts;

using Microsoft.EntityFrameworkCore;

namespace Conduit.Api.UseCases.Users.Queries.Login;

public class LoginQueryHandler : IQueryHandler<LoginQuery, AuthenticationResponse>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(ApplicationDbContext dbContext, JwtTokenGenerator jwtTokenGenerator)
    {
        _dbContext = dbContext;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResponse> Handle(
        LoginQuery query,
        CancellationToken cancellationToken
    )
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(
            u => u.Email == query.Email,
            cancellationToken
        );

        if (user is null || user.Password != query.Password)
        {
            throw new ApplicationException("Invalid Credentials");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResponse(user.Id, user.UserName, user.Email, token);
    }
}
