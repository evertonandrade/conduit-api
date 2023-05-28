using MediatR;

namespace Conduit.Api.Common.Abstractions;

interface IQueryHandler<in TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult>
    where TQuery : IQuery<TQueryResult> { }
