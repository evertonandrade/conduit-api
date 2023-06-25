using Conduit.Api.Common.Abstractions;

namespace Conduit.Api.Endpoints.Users;

public class LoginUserEndpoint : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("user", Handle);
    }

    IResult Handle(LoginUserRequest loginUser)
    {
        return Results.Ok();
    }

    record LoginUserRequest(string Email, string Password);
}