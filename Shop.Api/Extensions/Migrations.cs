using Microsoft.EntityFrameworkCore;

namespace Shop.Api.Extensions;

/// <summary>
/// Extension methods for handling DB migrations.
/// </summary>
public static class Migrations
{
    /// <summary>
    /// Applies a DB migration.
    /// </summary>
    /// <param name="builder">The application builder.</param>
    /// <typeparam name="T">The type of the DB context.</typeparam>
    public static async Task ApplyMigrations<T>(this IApplicationBuilder builder)
        where T: DbContext
    {
        await using var scope = builder.ApplicationServices.CreateAsyncScope();
        await using var context = scope.ServiceProvider.GetRequiredService<T>();
        await context.Database.MigrateAsync().ConfigureAwait(false);
    }
}
