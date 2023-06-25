using Conduit.Api.Common.Abstractions;
using Conduit.Api.Entities.Users;

namespace Conduit.Api.Endpoints.Users;

public class UpdateUserEndpoint : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("user/{userId}", Handle);
    }

    IResult Handle(UserId userId, UpdateUserRequest user)
    {
        return Results.NoContent();
    }

    record UpdateUserRequest();
}