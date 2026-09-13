using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ReportService.Api.Application;

namespace ReportService.Tests.Application;

public sealed class ReportProcessingOptionsTests
{
    private static readonly string _processingDurationKey =
        $"{ReportProcessingOptions.SectionName}:{nameof(ReportProcessingOptions.ProcessingDurationMs)}";

    [Fact]
    public void ApiAppSettingsFileSetsProcessingDurationToSixtySeconds()
    {
        var appSettings = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        Assert.Equal("60000", appSettings[_processingDurationKey]);
    }

    [Fact]
    public void ProcessingDurationDefaultsToSixtySecondsWhenNotConfigured()
    {
        var emptyConfiguration = new ConfigurationBuilder().Build();

        var options = ResolveOptions(emptyConfiguration);

        Assert.Equal(TimeSpan.FromSeconds(60), options.ProcessingDuration);
    }

    [Fact]
    public void ConfiguredProcessingDurationOverridesDefault()
    {
        var options = ResolveOptions(CreateConfiguration(processingDurationMs: "1500"));

        Assert.Equal(1500, options.ProcessingDurationMs);
        Assert.Equal(TimeSpan.FromMilliseconds(1500), options.ProcessingDuration);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("-1")]
    public void NonPositiveProcessingDurationIsRejected(string processingDurationMs)
    {
        var exception = Assert.Throws<OptionsValidationException>(
            () => ResolveOptions(CreateConfiguration(processingDurationMs)));

        Assert.Contains(nameof(ReportProcessingOptions.ProcessingDurationMs), exception.Message);
    }

    [Fact]
    public void InvalidProcessingDurationFailsStartupValidation()
    {
        using var provider = BuildServiceProvider(CreateConfiguration(processingDurationMs: "0"));
        var startupValidator = provider.GetRequiredService<IStartupValidator>();

        Assert.Throws<OptionsValidationException>(startupValidator.Validate);
    }

    private static IConfiguration CreateConfiguration(string processingDurationMs) =>
        new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?> { [_processingDurationKey] = processingDurationMs })
            .Build();

    private static ReportProcessingOptions ResolveOptions(IConfiguration configuration)
    {
        using var provider = BuildServiceProvider(configuration);

        return provider.GetRequiredService<IOptions<ReportProcessingOptions>>().Value;
    }

    private static ServiceProvider BuildServiceProvider(IConfiguration configuration) =>
        new ServiceCollection()
            .AddApplication(configuration)
            .BuildServiceProvider();
}
