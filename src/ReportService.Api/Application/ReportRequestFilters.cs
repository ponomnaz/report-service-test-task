using System.Linq.Expressions;
using ReportService.Api.Domain;

namespace ReportService.Api.Application;

public static class ReportRequestFilters
{
    public static Expression<Func<ReportRequest, bool>> ReadyToComplete(DateTimeOffset now, TimeSpan processingDuration)
    {
        var createdNoLaterThan = now - processingDuration;

        return request => request.Status == ReportRequestStatus.Pending && request.CreatedAt <= createdNoLaterThan;
    }
}
