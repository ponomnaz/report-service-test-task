using Microsoft.Extensions.Options;
using ReportService.Api.Domain;
using ReportService.Api.Infrastructure.Persistence;

namespace ReportService.Api.Application;

public sealed class ReportRequestService(
    ReportDbContext dbContext,
    ReportRequestCompletionService completionService,
    TimeProvider timeProvider,
    IOptions<ReportProcessingOptions> options)
{
    public async Task<Guid> CreateAsync(Guid userId, DateRange period, CancellationToken cancellationToken)
    {
        var request = ReportRequest.Create(userId, period, timeProvider.GetUtcNow());

        dbContext.ReportRequests.Add(request);
        await dbContext.SaveChangesAsync(cancellationToken);

        return request.Id;
    }

    public async Task<ReportRequestInfo?> GetInfoAsync(Guid requestId, CancellationToken cancellationToken)
    {
        var now = timeProvider.GetUtcNow();
        var request = await completionService.CompleteIfReadyAsync(requestId, now, cancellationToken);

        return request is null
            ? null
            : ReportRequestInfo.From(request, now, options.Value.ProcessingDuration);
    }
}
