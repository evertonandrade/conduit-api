using Conduit.Data;
using Conduit.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Conduit.Config;

public static class ApplicationBuilderExtensions
{
    public static void ConfigureAppBuilder(this WebApplicationBuilder builder)
    {
        builder.AddServices();
    }

    private static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlite(builder.Configuration.GetConnectionString("Default"))
        );
        builder.AddJwtAuthentication();
    }

    private static void AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
        builder.Services.AddTransient<JwtGenerator>();
        builder
            .Services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = JwtGenerator.SecurityKey(builder.Configuration["Jwt:Key"]!),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        builder.Services.AddAuthorization();
    }
}
