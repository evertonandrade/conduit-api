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

    async Task<IResult> Handle(RegisterRequest request, ICommandBus bus)
    {
        var response = await bus.Send(
            new RegisterUserCommand(request.Username, request.Email, request.Password)
        );

        return Results.Ok(response);
    }
}
