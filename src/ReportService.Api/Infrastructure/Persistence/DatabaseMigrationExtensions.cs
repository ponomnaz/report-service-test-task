using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportService.Api.Infrastructure.Persistence;

public static class DatabaseMigrationExtensions
{
    public static async Task MigrateDatabaseAsync(this IHost host, CancellationToken cancellationToken = default)
    {
        await using var scope = host.Services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ReportDbContext>();

        await dbContext.GetService<IHistoryRepository>().CreateIfNotExistsAsync(cancellationToken);
        await dbContext.Database.MigrateAsync(cancellationToken);
    }
}
