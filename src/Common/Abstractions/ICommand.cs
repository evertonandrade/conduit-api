using MediatR;

namespace Conduit.Api.Common.Abstractions;

public interface ICommand<out TCommandResult> : IRequest<TCommandResult> { }

public interface ICommand : IRequest { }
