namespace Conduit.Utils.Abstractions;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}
