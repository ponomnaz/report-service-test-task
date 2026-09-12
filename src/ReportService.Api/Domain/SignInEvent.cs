namespace ReportService.Api.Domain;

public sealed class SignInEvent
{
    public SignInEvent(Guid id, Guid userId, DateTimeOffset occurredAt)
    {
        Id = id;
        UserId = userId;
        OccurredAt = occurredAt.ToUniversalTime();
    }

    public Guid Id { get; }

    public Guid UserId { get; }

    public DateTimeOffset OccurredAt { get; }
}
