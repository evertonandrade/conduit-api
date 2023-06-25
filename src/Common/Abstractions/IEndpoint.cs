namespace Conduit.Api.Common.Abstractions;

public interface IEndpoint
{
    void Configure(IEndpointRouteBuilder endpoints);
}