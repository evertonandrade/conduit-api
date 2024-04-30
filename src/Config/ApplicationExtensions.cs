using Conduit.Data;
using Conduit.Endpoints;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Config;

public static class ApplicationExtensions
{
    public static void ConfigureApp(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.MapEndpoints();
        app.EnsureDatabaseCreated();
    }

    private static void EnsureDatabaseCreated(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }
}