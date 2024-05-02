using Conduit.Common.Abstractions;
using Conduit.Common.Filters;
using Conduit.Endpoints.Auth;

namespace Conduit.Endpoints;

public static class EndpointMappingExtensions
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
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
