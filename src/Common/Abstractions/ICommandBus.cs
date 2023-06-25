namespace Conduit.Api.Common.Abstractions;

public interface ICommandBus
{
    Task<TResponse> Send<TResponse>(
        ICommand<TResponse> request,
        CancellationToken cancellationToken = default
    );

    Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : ICommand;
}
