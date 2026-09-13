using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReportService.Api.Domain;
using ReportService.Api.Infrastructure.Persistence;

namespace ReportService.Api.Application;

public sealed class ReportRequestProcessingWorker(
    IServiceScopeFactory scopeFactory,
    TimeProvider timeProvider,
    IOptions<ReportProcessingOptions> options,
    ILogger<ReportRequestProcessingWorker> logger) : BackgroundService
{
    private const int MaxRequestsPerTick = 100;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(options.Value.PollingInterval, timeProvider);

        do
        {
            try
            {
                await CompleteReadyRequestsAsync(stoppingToken);
            }
            catch (Exception exception) when (!stoppingToken.IsCancellationRequested)
            {
                logger.LogError(exception, "Failed to process ready report requests; retrying on the next tick");
            }
        }
        while (await timer.WaitForNextTickAsync(stoppingToken));
    }

    private async Task CompleteReadyRequestsAsync(CancellationToken cancellationToken)
    {
        var now = timeProvider.GetUtcNow();
        var readyRequestIds = await FindReadyRequestIdsAsync(now, cancellationToken);
        var completedCount = 0;

        foreach (var requestId in readyRequestIds)
        {
            try
            {
                await using var scope = scopeFactory.CreateAsyncScope();
                var completionService = scope.ServiceProvider.GetRequiredService<ReportRequestCompletionService>();

                var request = await completionService.CompleteIfReadyAsync(requestId, now, cancellationToken);
                if (request is { Status: ReportRequestStatus.Completed })
                {
                    completedCount++;
                }
            }
            catch (Exception exception) when (!cancellationToken.IsCancellationRequested)
            {
                logger.LogError(exception, "Failed to complete report request {RequestId}; retrying on the next tick", requestId);
            }
        }

        if (readyRequestIds.Count > 0)
        {
            logger.LogInformation(
                "Completed {CompletedCount} of {ReadyCount} ready report requests",
                completedCount,
                readyRequestIds.Count);
        }
    }

    private async Task<List<Guid>> FindReadyRequestIdsAsync(DateTimeOffset now, CancellationToken cancellationToken)
    {
        await using var scope = scopeFactory.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ReportDbContext>();

        return await dbContext.ReportRequests
            .Where(ReportRequestFilters.ReadyToComplete(now, options.Value.ProcessingDuration))
            .OrderBy(request => request.CreatedAt)
            .Select(request => request.Id)
            .Take(MaxRequestsPerTick)
            .ToListAsync(cancellationToken);
    }
}
