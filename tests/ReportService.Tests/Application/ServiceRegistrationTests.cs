using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReportService.Api.Application;
using ReportService.Api.Infrastructure.Persistence;

namespace ReportService.Tests.Application;

public sealed class ServiceRegistrationTests
{
    [Theory]
    [InlineData(typeof(ReportRequestService))]
    [InlineData(typeof(ReportRequestCompletionService))]
    public void ApplicationServiceResolvesFromRealRegistrations(Type serviceType)
    {
        using var provider = BuildServiceProvider();
        using var scope = provider.CreateScope();

        Assert.NotNull(scope.ServiceProvider.GetRequiredService(serviceType));
    }

    [Fact]
    public void ProcessingWorkerIsRegisteredAsHostedService()
    {
        using var provider = BuildServiceProvider();

        Assert.Contains(provider.GetServices<IHostedService>(), service => service is ReportRequestProcessingWorker);
    }

    [Fact]
    public void SystemClockIsRegistered()
    {
        using var provider = BuildServiceProvider();

        Assert.Same(TimeProvider.System, provider.GetRequiredService<TimeProvider>());
    }

    private static ServiceProvider BuildServiceProvider()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:ReportDb"] = "Host=127.0.0.1;Database=report_service",
            })
            .Build();

        return new ServiceCollection()
            .AddLogging()
            .AddApplication(configuration)
            .AddPersistence(configuration)
            .BuildServiceProvider(new ServiceProviderOptions { ValidateOnBuild = true, ValidateScopes = true });
    }
}
