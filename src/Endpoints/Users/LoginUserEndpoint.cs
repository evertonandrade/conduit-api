using Conduit.Api.Common.Abstractions;
using Conduit.Api.UseCases.Users.Contracts;
using Conduit.Api.UseCases.Users.Queries.Login;

namespace Conduit.Api.Endpoints.Users;

public class LoginUserEndpoint : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("users/login", Handle);
    }

    async Task<IResult> Handle(
        IQueryDispatcher queryDispatcher,
        LoginRequest request,
        CancellationToken cancellationToken
    )
    {
        var response = await queryDispatcher.Dispatch(
            new LoginQuery(request.Email, request.Password),
            cancellationToken
        );
        return Results.Ok(response);
    }
}
