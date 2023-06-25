using System.Reflection;
using Conduit.Api.Common.Abstractions;

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
    }
}
