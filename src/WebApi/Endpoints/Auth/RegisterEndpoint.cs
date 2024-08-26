using Conduit.Data;
using Conduit.Entities;
using Conduit.Extensions;
using Conduit.Utils.Abstractions;
using Conduit.Utils.Auth;

using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Endpoints.Auth;

public class RegisterEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", Handle)
            .WithSummary("Register a new user")
            .WithRequestValidation<RegisterRequest>();

    static async Task<Results<Ok<RegisterResponse>, Conflict>> Handle(
        AppDbContext dbContext,
        JwtGenerator jwtGenerator,
        RegisterRequest request,
        CancellationToken ct
    )
    {
        var isEmailTaken = await dbContext.Users.AnyAsync(u => u.Email == request.Email, ct);
        if (isEmailTaken)
        {
            return TypedResults.Conflict();
        }

        var user = new User
        {
            Email = request.Email,
            Password = PasswordHasher.Hash(request.Password),
            Profile = new Profile { Username = request.Username }
        };
        await dbContext.Users.AddAsync(user, ct);
        await dbContext.SaveChangesAsync(ct);

        var response = new RegisterResponse(
            Email: user.Email,
            Token: jwtGenerator.GenerateToken(user),
            Bio: user.Profile?.Bio,
            Username: user.Profile?.Username,
            Image: user.Profile?.ImageUrl
        );

        return TypedResults.Ok(response);
    }

    public record RegisterRequest(string Username, string Email, string Password);

    public record RegisterResponse(
        string Email,
        string Token,
        string? Username,
        string? Bio,
        string? Image
    );

    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(r => r.Username).NotEmpty();
            RuleFor(r => r.Email).EmailAddress();
            RuleFor(r => r.Password).NotEmpty().MinimumLength(8);
        }
    }
}
