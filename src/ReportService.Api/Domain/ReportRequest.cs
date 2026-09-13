namespace ReportService.Api.Domain;

public sealed class ReportRequest
{
    private const int CompletePercent = 100;

    private ReportRequest()
    {
        Period = null!;
    }

    private ReportRequest(Guid id, Guid userId, DateRange period, DateTimeOffset createdAt)
    {
        Id = id;
        UserId = userId;
        Period = period;
        CreatedAt = createdAt;
        Status = ReportRequestStatus.Pending;
    }

    public Guid Id { get; }

    public Guid UserId { get; }

    public DateRange Period { get; }

    public DateTimeOffset CreatedAt { get; }

    public ReportRequestStatus Status { get; private set; }

    public DateTimeOffset? CompletedAt { get; private set; }

    public int? CountSignIn { get; private set; }

    public static ReportRequest Create(Guid userId, DateRange period, DateTimeOffset createdAt)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("User id must not be empty.", nameof(userId));
        }

        var createdAtUtc = createdAt.ToUniversalTime();

        return new ReportRequest(Guid.CreateVersion7(createdAtUtc), userId, period, createdAtUtc);
    }

    public int CalculateProgressPercent(DateTimeOffset now, TimeSpan processingDuration)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(processingDuration, TimeSpan.Zero);

        if (Status == ReportRequestStatus.Completed)
        {
            return CompletePercent;
        }

        var elapsed = now - CreatedAt;

        if (elapsed <= TimeSpan.Zero)
        {
            return 0;
        }

        if (elapsed >= processingDuration)
        {
            return CompletePercent;
        }

        // Integer ticks instead of double division: 17.4 s of 60 s must floor to 29, not 28.
        return (int)(elapsed.Ticks * CompletePercent / processingDuration.Ticks);
    }

    public bool IsReadyToComplete(DateTimeOffset now, TimeSpan processingDuration) =>
        Status == ReportRequestStatus.Pending && CalculateProgressPercent(now, processingDuration) == CompletePercent;

    public void Complete(int countSignIn, DateTimeOffset now, TimeSpan processingDuration)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(countSignIn);

        if (Status == ReportRequestStatus.Completed)
        {
            return;
        }

        if (!IsReadyToComplete(now, processingDuration))
        {
            throw new InvalidOperationException(
                $"Report request {Id} cannot be completed before its processing duration of {processingDuration} elapses.");
        }

        Status = ReportRequestStatus.Completed;
        CountSignIn = countSignIn;
        CompletedAt = now.ToUniversalTime();
    }
}
