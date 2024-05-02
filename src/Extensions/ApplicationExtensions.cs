using Conduit.Data;
using Conduit.Endpoints;

using Microsoft.EntityFrameworkCore;

namespace Conduit.Extensions;

public static class ApplicationExtensions
{
    public static void ConfigureApp(this WebApplication app)
    {
        app.MapEndpoints();
        app.UseHttpsRedirection();
        app.EnsureDatabaseCreated();
    }

    private static void EnsureDatabaseCreated(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }
}
