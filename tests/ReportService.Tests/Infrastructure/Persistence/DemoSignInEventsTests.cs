using ReportService.Api.Infrastructure.Persistence.Seed;

namespace ReportService.Tests.Infrastructure.Persistence;

public sealed class DemoSignInEventsTests
{
    [Fact]
    public void TaskExampleUserSignedInTwelveTimesInJanuary()
    {
        var count = CountSignIns(DemoSignInEvents.TaskExampleUserId, new DateOnly(2026, 1, 1), new DateOnly(2026, 1, 31));

        Assert.Equal(12, count);
    }

    [Theory]
    [InlineData("2026-02-01", "2026-02-28", 8, 15)]
    [InlineData("2026-01-01", "2026-03-31", 25, 27)]
    public void EachUserHasOwnSignInCount(string from, string to, int taskExampleUserCount, int otherUserCount)
    {
        var period = (From: DateOnly.Parse(from), To: DateOnly.Parse(to));

        Assert.Equal(taskExampleUserCount, CountSignIns(DemoSignInEvents.TaskExampleUserId, period.From, period.To));
        Assert.Equal(otherUserCount, CountSignIns(DemoSignInEvents.OtherUserId, period.From, period.To));
    }

    [Theory]
    [InlineData("2026-02-01", "2026-02-28", 2)]
    [InlineData("2026-01-31", "2026-03-01", 4)]
    [InlineData("2026-02-01", "2026-02-01", 1)]
    [InlineData("2026-02-02", "2026-02-27", 0)]
    public void BoundaryUserSignInsSitExactlyOnDayEdges(string from, string to, int expectedCount)
    {
        var count = CountSignIns(DemoSignInEvents.BoundaryUserId, DateOnly.Parse(from), DateOnly.Parse(to));

        Assert.Equal(expectedCount, count);
    }

    [Fact]
    public void SeedIdsAreUnique()
    {
        var ids = DemoSignInEvents.All.Select(signIn => signIn.Id).ToArray();

        Assert.Equal(ids.Length, ids.Distinct().Count());
    }

    private static int CountSignIns(Guid userId, DateOnly from, DateOnly to)
    {
        var periodStart = new DateTimeOffset(from, TimeOnly.MinValue, TimeSpan.Zero);
        var periodEndExclusive = new DateTimeOffset(to.AddDays(1), TimeOnly.MinValue, TimeSpan.Zero);

        return DemoSignInEvents.All.Count(signIn =>
            signIn.UserId == userId && signIn.OccurredAt >= periodStart && signIn.OccurredAt < periodEndExclusive);
    }
}
