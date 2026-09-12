using Microsoft.EntityFrameworkCore;

namespace ReportService.Api.Infrastructure.Persistence;

public static class PersistenceServiceCollectionExtensions
{
    private const string ConnectionStringName = "ReportDb";

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName)
            ?? throw new InvalidOperationException($"Connection string '{ConnectionStringName}' is not configured.");

        services.AddDbContext<ReportDbContext>(options => options
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention());

        return services;
    }
}
