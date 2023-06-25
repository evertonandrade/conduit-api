using Conduit.Api.Common.Abstractions;
using Conduit.Api.UseCases.Users.Contracts;
using Conduit.Api.UseCases.Users.Queries.Login;
using MediatR;

namespace Conduit.Api.Endpoints.Users;

public class LoginUserEndpoint : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("users", Handle);
    }

    async Task<IResult> Handle(IMediator mediator, LoginRequest request)
    {
        var response = await mediator.Send(new LoginQuery(request.Email, request.Password));
        return Results.Ok(response);
    }
}
