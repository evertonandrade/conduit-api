using MediatR;

namespace Conduit.Api.Common.Abstractions;

interface ICommandHandler<in TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult>
    where TCommand : ICommand<TCommandResult> { }
