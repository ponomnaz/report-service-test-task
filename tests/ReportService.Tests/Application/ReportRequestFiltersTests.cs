using ReportService.Api.Application;
using ReportService.Api.Domain;

namespace ReportService.Tests.Application;

public sealed class ReportRequestFiltersTests
{
    private static readonly DateTimeOffset _createdAt = new(2026, 2, 1, 12, 0, 0, TimeSpan.Zero);
    private static readonly TimeSpan _processingDuration = TimeSpan.FromSeconds(60);
    private static readonly DateTimeOffset _processingDeadline = _createdAt + _processingDuration;

    [Fact]
    public void PendingRequestIsNotSelectedBeforeDeadline()
    {
        var request = CreatePendingRequest();

        Assert.False(IsSelectedAsReady(request, _processingDeadline.AddMilliseconds(-1)));
    }

    [Fact]
    public void PendingRequestIsSelectedAtDeadline()
    {
        var request = CreatePendingRequest();

        Assert.True(IsSelectedAsReady(request, _processingDeadline));
    }

    [Fact]
    public void CompletedRequestIsNeverSelected()
    {
        var request = CreatePendingRequest();
        request.Complete(countSignIn: 12, _processingDeadline, _processingDuration);

        Assert.False(IsSelectedAsReady(request, _processingDeadline.AddHours(1)));
    }

    [Theory]
    [InlineData(-3_600_000)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(3_600_000)]
    public void FilterAgreesWithDomainReadinessRule(int millisecondsFromDeadline)
    {
        var request = CreatePendingRequest();
        var now = _processingDeadline.AddMilliseconds(millisecondsFromDeadline);

        Assert.Equal(request.IsReadyToComplete(now, _processingDuration), IsSelectedAsReady(request, now));
    }

    private static bool IsSelectedAsReady(ReportRequest request, DateTimeOffset now) =>
        ReportRequestFilters.ReadyToComplete(now, _processingDuration).Compile()(request);

    private static ReportRequest CreatePendingRequest() =>
        ReportRequest.Create(
            Guid.Parse("b28d0ced-8af5-4c94-8650-c7946241fd1a"),
            new DateRange(new DateOnly(2026, 1, 1), new DateOnly(2026, 1, 31)),
            _createdAt);
}
