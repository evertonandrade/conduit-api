using MediatR;

namespace Conduit.Api.Common.Abstractions;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IMediator _mediator;
    private readonly ILogger<QueryDispatcher> _logger;

    public QueryDispatcher(IMediator mediator, ILogger<QueryDispatcher> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public Task<TQueryResult> Dispatch<TQueryResult>(
        IQuery<TQueryResult> query,
        CancellationToken cancellationToken = default
    )
    {
        _logger.LogInformation("Executing query: {query}", query);
        return _mediator.Send(query, cancellationToken);
    }
}
