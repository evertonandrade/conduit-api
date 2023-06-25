namespace Conduit.Api.Common.Abstractions;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQueryResult>(
        IQuery<TQueryResult> query,
        CancellationToken cancellationToken = default
    );
}
