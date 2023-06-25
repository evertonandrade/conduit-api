using MediatR;

namespace Conduit.Api.Common.Abstractions;

public interface IQuery<out TIQueryResult> : IRequest<TIQueryResult> { }
