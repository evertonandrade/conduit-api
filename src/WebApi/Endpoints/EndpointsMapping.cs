using Conduit.Endpoints.Auth;
using Conduit.Endpoints.Users;
using Conduit.Filters;
using Conduit.Utils.Abstractions;

namespace Conduit.Endpoints;

public static class EndpointsMapping
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/api")
            .AddEndpointFilter<RequestLoggingFilter>()
            .RequireAuthorization();

        endpoints
            .MapGroup("/users")
            .WithTags("Authentication")
            .AllowAnonymous()
            .MapEndpoint<RegisterEndpoint>()
            .MapEndpoint<LoginEdpoint>();

        endpoints.MapGroup("/users")
            .MapEndpoint<GetCurrentUserEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
