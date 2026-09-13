using ReportService.Api.Domain;

namespace ReportService.Api.Application;

public sealed record ReportRequestInfo(Guid RequestId, int Percent, UserStatistics? Result)
{
    public static ReportRequestInfo From(ReportRequest request, DateTimeOffset now, TimeSpan processingDuration) =>
        new(
            request.Id,
            request.CalculateProgressPercent(now, processingDuration),
            request is { Status: ReportRequestStatus.Completed, CountSignIn: { } countSignIn }
                ? new UserStatistics(request.UserId, countSignIn)
                : null);
}
