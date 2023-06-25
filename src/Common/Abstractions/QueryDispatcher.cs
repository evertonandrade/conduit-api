using MediatR;

namespace Conduit.Api.Common.Abstractions;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IMediator _mediator;

    public QueryDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<TQueryResult> Dispatch<TQueryResult>(
        IQuery<TQueryResult> query,
        CancellationToken cancellationToken = default
    )
    {
        return _mediator.Send(query, cancellationToken);
    }
}
