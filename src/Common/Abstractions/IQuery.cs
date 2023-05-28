using MediatR;

namespace Conduit.Api.Common.Abstractions;

interface IQuery<out TIQueryResult> : IRequest<TIQueryResult> { }
