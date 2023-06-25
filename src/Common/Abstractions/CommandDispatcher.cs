using MediatR;

namespace Conduit.Api.Common.Abstractions;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IMediator _mediator;
    private readonly ILogger<CommandDispatcher> _logger;

    public CommandDispatcher(IMediator mediator, ILogger<CommandDispatcher> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public Task<TCommandResult> Dispatch<TCommandResult>(
        ICommand<TCommandResult> command,
        CancellationToken cancellationToken = default
    )
    {
        _logger.LogInformation("Sending command: {command}", command);
        return _mediator.Send(command, cancellationToken);
    }

    public Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : ICommand
    {
        _logger.LogInformation("Sending command: {command}", command);
        return _mediator.Send(command, cancellationToken);
    }
}
