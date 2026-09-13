namespace ReportService.Api.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<ReportProcessingOptions>()
            .Bind(configuration.GetSection(ReportProcessingOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddSingleton(TimeProvider.System);
        services.AddScoped<ReportRequestService>();
        services.AddScoped<ReportRequestCompletionService>();
        services.AddHostedService<ReportRequestProcessingWorker>();

        return services;
    }
}
