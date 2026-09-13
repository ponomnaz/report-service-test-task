using ReportService.Api.Application;

namespace ReportService.Api.Contracts;

public sealed record ReportInfoResponse(Guid Query, int Percent, UserStatisticsResponse? Result)
{
    public static ReportInfoResponse From(ReportRequestInfo info) =>
        new(
            info.RequestId,
            info.Percent,
            info.Result is { } result ? new UserStatisticsResponse(result.UserId, result.CountSignIn) : null);
}
