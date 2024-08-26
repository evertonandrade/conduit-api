using Conduit.Utils.Abstractions;

using Microsoft.AspNetCore.Http.HttpResults;

namespace Conduit.Endpoints.Users;

public class GetCurrentUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => 
        app.MapGet("/", Handle)
        .RequireAuthorization();

    static Ok<string> Handle(HttpContext context)
    {
        return TypedResults.Ok("Teste");
    }
}