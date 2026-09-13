using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Api.Application;
using ReportService.Api.Infrastructure.Persistence;

namespace ReportService.Tests.Application;

public sealed class ServiceRegistrationTests
{
    [Fact]
    public void ReportRequestServiceResolvesFromApplicationAndPersistenceRegistrations()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:ReportDb"] = "Host=localhost;Database=report_service",
            })
            .Build();

        using var provider = new ServiceCollection()
            .AddApplication(configuration)
            .AddPersistence(configuration)
            .BuildServiceProvider(new ServiceProviderOptions { ValidateOnBuild = true, ValidateScopes = true });
        using var scope = provider.CreateScope();

        Assert.NotNull(scope.ServiceProvider.GetRequiredService<ReportRequestService>());
        Assert.Same(TimeProvider.System, provider.GetRequiredService<TimeProvider>());
    }
}
