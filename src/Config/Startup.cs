using System.Reflection;
using Conduit.Api.Common.Abstractions;
using Conduit.Api.Common.Authentication;

namespace Conduit.Api.Config;

public static class Startup
{
    internal static void RegisterEndpoints(IEndpointRouteBuilder endpoints)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var endpointTypes = assembly
            .GetExportedTypes()
            .Where(type => !type.IsAbstract && typeof(IEndpoint).IsAssignableFrom(type));

        foreach (var endpointType in endpointTypes)
        {
            var endpoint = Activator.CreateInstance(endpointType) as IEndpoint;
            endpoint?.Configure(endpoints);
        }
    }

    internal static void AddCqrs(this IServiceCollection services)
    {
        services.AddMediatR(
            config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
    }

    internal static void AddJwtConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<JwtTokenGenerator>();
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
    }
}
