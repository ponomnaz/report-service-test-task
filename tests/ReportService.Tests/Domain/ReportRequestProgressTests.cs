using ReportService.Api.Domain;

namespace ReportService.Tests.Domain;

public sealed class ReportRequestProgressTests
{
    private const int DefaultProcessingDurationMs = 60_000;

    private static readonly DateTimeOffset _createdAt = new(2026, 2, 1, 12, 0, 0, TimeSpan.Zero);
    private static readonly TimeSpan _defaultProcessingDuration = TimeSpan.FromMilliseconds(DefaultProcessingDurationMs);

    [Theory]
    [InlineData(0, 0)]
    [InlineData(30, 50)]
    [InlineData(45, 75)]
    [InlineData(60, 100)]
    public void ProgressMatchesTaskExamplesForDefaultDuration(int elapsedSeconds, int expectedPercent)
    {
        var request = CreatePendingRequest();

        var percent = request.CalculateProgressPercent(_createdAt.AddSeconds(elapsedSeconds), _defaultProcessingDuration);

        Assert.Equal(expectedPercent, percent);
    }

    [Fact]
    public void ProgressStaysBelowHundredUntilFullDurationElapses()
    {
        var request = CreatePendingRequest();
        var oneMillisecondBeforeDeadline = _createdAt.AddMilliseconds(DefaultProcessingDurationMs - 1);

        var percent = request.CalculateProgressPercent(oneMillisecondBeforeDeadline, _defaultProcessingDuration);

        Assert.Equal(99, percent);
    }

    [Fact]
    public void ProgressIsCappedAtHundredAfterDurationElapses()
    {
        var request = CreatePendingRequest();

        var percent = request.CalculateProgressPercent(_createdAt.AddMinutes(2), _defaultProcessingDuration);

        Assert.Equal(100, percent);
    }

    [Fact]
    public void ProgressIsRoundedDownRatherThanToNearest()
    {
        var request = CreatePendingRequest();

        var percent = request.CalculateProgressPercent(_createdAt.AddMilliseconds(17_400), _defaultProcessingDuration);

        Assert.Equal(29, percent);
    }

    [Fact]
    public void ProgressScalesWithConfiguredDuration()
    {
        var request = CreatePendingRequest();

        var percent = request.CalculateProgressPercent(_createdAt.AddMilliseconds(250), TimeSpan.FromMilliseconds(1_000));

        Assert.Equal(25, percent);
    }

    [Fact]
    public void ProgressIsZeroWhenClockIsBehindCreationTime()
    {
        var request = CreatePendingRequest();

        var percent = request.CalculateProgressPercent(_createdAt.AddSeconds(-5), _defaultProcessingDuration);

        Assert.Equal(0, percent);
    }

    [Fact]
    public void ProgressDoesNotDependOnClockOffset()
    {
        var request = CreatePendingRequest();
        var thirtySecondsLaterInMoscowTime = _createdAt.AddSeconds(30).ToOffset(TimeSpan.FromHours(3));

        var percent = request.CalculateProgressPercent(thirtySecondsLaterInMoscowTime, _defaultProcessingDuration);

        Assert.Equal(50, percent);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ProgressRejectsNonPositiveDuration(int processingDurationMs)
    {
        var request = CreatePendingRequest();

        Assert.Throws<ArgumentOutOfRangeException>(
            () => request.CalculateProgressPercent(_createdAt, TimeSpan.FromMilliseconds(processingDurationMs)));
    }

    private static ReportRequest CreatePendingRequest() =>
        ReportRequest.Create(
            Guid.Parse("b28d0ced-8af5-4c94-8650-c7946241fd1a"),
            new DateRange(new DateOnly(2026, 1, 1), new DateOnly(2026, 1, 31)),
            _createdAt);
}
