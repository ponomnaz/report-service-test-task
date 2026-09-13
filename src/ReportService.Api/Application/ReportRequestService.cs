using ReportService.Api.Domain;
using ReportService.Api.Infrastructure.Persistence;

namespace ReportService.Api.Application;

public sealed class ReportRequestService(ReportDbContext dbContext, TimeProvider timeProvider)
{
    public async Task<Guid> CreateAsync(Guid userId, DateRange period, CancellationToken cancellationToken)
    {
        var request = ReportRequest.Create(userId, period, timeProvider.GetUtcNow());

        dbContext.ReportRequests.Add(request);
        await dbContext.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}
