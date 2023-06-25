using Conduit.Api.Common.Abstractions;
using Conduit.Api.UseCases.Users.Commands.Register;
using Conduit.Api.UseCases.Users.Contracts;

namespace Conduit.Api.Endpoints.Users;

public class RegisterUserEndpoint : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("users", Handle);
    }

    async Task<IResult> Handle(
        ICommandDispatcher commandDispatcher,
        RegisterRequest request,
        CancellationToken cancellationToken
    )
    {
        var response = await commandDispatcher.Dispatch(
            new RegisterUserCommand(request.Username, request.Email, request.Password),
            cancellationToken
        );

        return Results.Ok(response);
    }
}
