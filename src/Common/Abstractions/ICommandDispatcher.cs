namespace Conduit.Api.Common.Abstractions;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommandResult>(
        ICommand<TCommandResult> command,
        CancellationToken cancellationToken = default
    );

    Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : ICommand;
}
