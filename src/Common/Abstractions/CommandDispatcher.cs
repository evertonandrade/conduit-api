using MediatR;

namespace Conduit.Api.Common.Abstractions;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IMediator _mediator;

    public CommandDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<TCommandResult> Dispatch<TCommandResult>(ICommand<TCommandResult> command, CancellationToken cancellationToken = default)
    {
        return _mediator.Send(command, cancellationToken);
    }

    public Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
    {
        return _mediator.Send(command, cancellationToken);
    }
}
