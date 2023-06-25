using Conduit.Api.Common.Abstractions;

namespace Conduit.Api.Endpoints.Users;

public class RegisterUserEndpoint : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("user", Handle);
    }

    Task Handle(HttpContext context)
    {
        throw new NotImplementedException();
    }

    record RegisterUserRequest();
}