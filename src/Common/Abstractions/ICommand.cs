using MediatR;

namespace Conduit.Api.Common.Abstractions;

interface ICommand<out TCommandResult> : IRequest<TCommandResult> { }
