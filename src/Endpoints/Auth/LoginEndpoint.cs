using Conduit.Abstractions;
using Conduit.Data;
using Conduit.Utils;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Endpoints.Auth;

public class LoginEdpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/login", Handle).WithSummary("Existing user login");

    static async Task<Results<Ok<LoginResponse>, UnauthorizedHttpResult>> Handle(
        AppDbContext dbContext,
        JwtGenerator jwtGenerator,
        LoginRequest req,
        CancellationToken ct
    )
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == req.Email, ct);
        // TODO: hash password
        if (user is null || user.Password != req.Password)
        {
            return TypedResults.Unauthorized();
        }

        var response = new LoginResponse(
            Email: user.Email,
            Token: jwtGenerator.GenerateToken(user),
            Bio: user.Profile?.Bio,
            Username: user.Profile?.Username,
            Image: user.Profile?.ImageUrl
        );

        return TypedResults.Ok(response);
    }

    record LoginRequest(string Email, string Password);

    class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(r => r.Email).EmailAddress();
            RuleFor(r => r.Password).NotNull().NotEmpty();
        }
    }

    record LoginResponse(string Email, string Token, string? Username, string? Bio, string? Image);
}
