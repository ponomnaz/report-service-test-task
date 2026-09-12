using ReportService.Api.Domain;

namespace ReportService.Tests.Domain;

public sealed class SignInEventTests
{
    [Fact]
    public void OccurredAtIsNormalizedToUtc()
    {
        var occurredAtInMoscowTime = new DateTimeOffset(2026, 1, 10, 15, 30, 0, TimeSpan.FromHours(3));

        var signIn = new SignInEvent(Guid.NewGuid(), Guid.NewGuid(), occurredAtInMoscowTime);

        Assert.Equal(TimeSpan.Zero, signIn.OccurredAt.Offset);
        Assert.Equal(occurredAtInMoscowTime, signIn.OccurredAt);
    }
}
