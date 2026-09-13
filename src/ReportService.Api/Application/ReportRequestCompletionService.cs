using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReportService.Api.Domain;
using ReportService.Api.Infrastructure.Persistence;

namespace ReportService.Api.Application;

public sealed class ReportRequestCompletionService(ReportDbContext dbContext, IOptions<ReportProcessingOptions> options)
{
    public async Task<ReportRequest?> CompleteIfReadyAsync(
        Guid requestId,
        DateTimeOffset now,
        CancellationToken cancellationToken)
    {
        var request = await dbContext.ReportRequests
            .SingleOrDefaultAsync(storedRequest => storedRequest.Id == requestId, cancellationToken);

        if (request is null)
        {
            return null;
        }

        var processingDuration = options.Value.ProcessingDuration;

        if (!request.IsReadyToComplete(now, processingDuration))
        {
            return request;
        }

        var countSignIn = await CountSignInsAsync(request.UserId, request.Period, cancellationToken);
        request.Complete(countSignIn, now, processingDuration);

        try
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            await dbContext.Entry(request).ReloadAsync(cancellationToken);
        }

        return request;
    }

    private Task<int> CountSignInsAsync(Guid userId, DateRange period, CancellationToken cancellationToken)
    {
        var periodStart = period.StartUtc;
        var periodEnd = period.EndUtcExclusive;

        return dbContext.SignInEvents.CountAsync(
            signIn => signIn.UserId == userId && signIn.OccurredAt >= periodStart && signIn.OccurredAt < periodEnd,
            cancellationToken);
    }
}
