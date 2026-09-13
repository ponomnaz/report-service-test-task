using ReportService.Api.Domain;

namespace ReportService.Tests.Domain;

public sealed class ReportRequestCompletionTests
{
    private static readonly DateTimeOffset _createdAt = new(2026, 2, 1, 12, 0, 0, TimeSpan.Zero);
    private static readonly TimeSpan _processingDuration = TimeSpan.FromSeconds(60);
    private static readonly DateTimeOffset _processingDeadline = _createdAt + _processingDuration;

    [Fact]
    public void PendingRequestIsNotReadyBeforeProcessingDurationElapses()
    {
        var request = CreatePendingRequest();

        Assert.False(request.IsReadyToComplete(_processingDeadline.AddMilliseconds(-1), _processingDuration));
    }

    [Fact]
    public void PendingRequestIsReadyOnceProcessingDurationElapses()
    {
        var request = CreatePendingRequest();

        Assert.True(request.IsReadyToComplete(_processingDeadline, _processingDuration));
    }

    [Fact]
    public void CompleteStoresResultAndMarksRequestCompleted()
    {
        var request = CreatePendingRequest();

        request.Complete(countSignIn: 12, _processingDeadline, _processingDuration);

        Assert.Equal(ReportRequestStatus.Completed, request.Status);
        Assert.Equal(12, request.CountSignIn);
        Assert.Equal(_processingDeadline, request.CompletedAt);
    }

    [Fact]
    public void ZeroSignInsIsValidResult()
    {
        var request = CreatePendingRequest();

        request.Complete(countSignIn: 0, _processingDeadline, _processingDuration);

        Assert.Equal(0, request.CountSignIn);
    }

    [Fact]
    public void NegativeSignInCountIsRejected()
    {
        var request = CreatePendingRequest();

        Assert.Throws<ArgumentOutOfRangeException>(
            () => request.Complete(countSignIn: -1, _processingDeadline, _processingDuration));
    }

    [Fact]
    public void CompleteBeforeProcessingDurationElapsesIsRejected()
    {
        var request = CreatePendingRequest();

        Assert.Throws<InvalidOperationException>(
            () => request.Complete(countSignIn: 12, _processingDeadline.AddMilliseconds(-1), _processingDuration));
        Assert.Equal(ReportRequestStatus.Pending, request.Status);
    }

    [Fact]
    public void RepeatedCompleteKeepsFirstResult()
    {
        var request = CreatePendingRequest();
        request.Complete(countSignIn: 12, _processingDeadline, _processingDuration);

        request.Complete(countSignIn: 5, _processingDeadline.AddSeconds(10), _processingDuration);

        Assert.Equal(12, request.CountSignIn);
        Assert.Equal(_processingDeadline, request.CompletedAt);
    }

    [Fact]
    public void CompletedRequestIsNeverReadyAgain()
    {
        var request = CreatePendingRequest();
        request.Complete(countSignIn: 12, _processingDeadline, _processingDuration);

        Assert.False(request.IsReadyToComplete(_processingDeadline.AddHours(1), _processingDuration));
    }

    [Fact]
    public void CompletedAtIsNormalizedToUtc()
    {
        var request = CreatePendingRequest();
        var deadlineInMoscowTime = _processingDeadline.ToOffset(TimeSpan.FromHours(3));

        request.Complete(countSignIn: 12, deadlineInMoscowTime, _processingDuration);

        Assert.Equal(TimeSpan.Zero, request.CompletedAt!.Value.Offset);
        Assert.Equal(deadlineInMoscowTime, request.CompletedAt);
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(0)]
    [InlineData(30)]
    public void CompletedRequestReportsHundredPercentAtAnyTime(int secondsSinceCreation)
    {
        var request = CreatePendingRequest();
        request.Complete(countSignIn: 12, _processingDeadline, _processingDuration);

        var percent = request.CalculateProgressPercent(_createdAt.AddSeconds(secondsSinceCreation), _processingDuration);

        Assert.Equal(100, percent);
    }

    private static ReportRequest CreatePendingRequest() =>
        ReportRequest.Create(
            Guid.Parse("b28d0ced-8af5-4c94-8650-c7946241fd1a"),
            new DateRange(new DateOnly(2026, 1, 1), new DateOnly(2026, 1, 31)),
            _createdAt);
}
