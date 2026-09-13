using ReportService.Api.Application;
using ReportService.Api.Domain;

namespace ReportService.Tests.Application;

public sealed class ReportRequestInfoTests
{
    private static readonly Guid _userId = Guid.Parse("b28d0ced-8af5-4c94-8650-c7946241fd1a");
    private static readonly DateTimeOffset _createdAt = new(2026, 2, 1, 12, 0, 0, TimeSpan.Zero);
    private static readonly TimeSpan _processingDuration = TimeSpan.FromSeconds(60);
    private static readonly DateTimeOffset _processingDeadline = _createdAt + _processingDuration;

    [Theory]
    [InlineData(0, 0)]
    [InlineData(30, 50)]
    [InlineData(45, 75)]
    public void PendingRequestReportsProgressWithoutResult(int elapsedSeconds, int expectedPercent)
    {
        var request = CreateRequest();

        var info = ReportRequestInfo.From(request, _createdAt.AddSeconds(elapsedSeconds), _processingDuration);

        Assert.Equal(request.Id, info.RequestId);
        Assert.Equal(expectedPercent, info.Percent);
        Assert.Null(info.Result);
    }

    [Fact]
    public void CompletedRequestReportsHundredPercentWithResult()
    {
        var request = CreateRequest();
        request.Complete(countSignIn: 12, _processingDeadline, _processingDuration);

        var info = ReportRequestInfo.From(request, _processingDeadline, _processingDuration);

        Assert.Equal(request.Id, info.RequestId);
        Assert.Equal(100, info.Percent);
        Assert.Equal(new UserStatistics(_userId, 12), info.Result);
    }

    [Fact]
    public void ZeroSignInsIsReportedAsResultRatherThanMissing()
    {
        var request = CreateRequest();
        request.Complete(countSignIn: 0, _processingDeadline, _processingDuration);

        var info = ReportRequestInfo.From(request, _processingDeadline, _processingDuration);

        Assert.Equal(new UserStatistics(_userId, 0), info.Result);
    }

    private static ReportRequest CreateRequest() =>
        ReportRequest.Create(_userId, new DateRange(new DateOnly(2026, 1, 1), new DateOnly(2026, 1, 31)), _createdAt);
}
