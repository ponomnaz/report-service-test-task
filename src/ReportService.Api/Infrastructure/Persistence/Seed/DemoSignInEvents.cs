using ReportService.Api.Domain;

namespace ReportService.Api.Infrastructure.Persistence.Seed;

public static class DemoSignInEvents
{
    public static readonly Guid TaskExampleUserId = Guid.Parse("b28d0ced-8af5-4c94-8650-c7946241fd1a");
    public static readonly Guid OtherUserId = Guid.Parse("4c1f9e2a-7b3d-4f8e-a6c5-2d9b0e1f3a7c");
    public static readonly Guid BoundaryUserId = Guid.Parse("8e2d4b6a-1c3f-4a5e-9b7d-0f2a4c6e8b1d");

    public static IReadOnlyList<SignInEvent> All { get; } = CreateEvents();

    private static SignInEvent[] CreateEvents()
    {
        (Guid UserId, DateTimeOffset OccurredAt)[] occurrences =
        [
            .. SpreadOverMonth(TaskExampleUserId, new DateOnly(2026, 1, 1), signInCount: 12),
            .. SpreadOverMonth(TaskExampleUserId, new DateOnly(2026, 2, 1), signInCount: 8),
            .. SpreadOverMonth(TaskExampleUserId, new DateOnly(2026, 3, 1), signInCount: 5),
            .. SpreadOverMonth(OtherUserId, new DateOnly(2026, 1, 1), signInCount: 3),
            .. SpreadOverMonth(OtherUserId, new DateOnly(2026, 2, 1), signInCount: 15),
            .. SpreadOverMonth(OtherUserId, new DateOnly(2026, 3, 1), signInCount: 9),
            (BoundaryUserId, new DateTimeOffset(2026, 1, 31, 23, 59, 59, TimeSpan.Zero)),
            (BoundaryUserId, new DateTimeOffset(2026, 2, 1, 0, 0, 0, TimeSpan.Zero)),
            (BoundaryUserId, new DateTimeOffset(2026, 2, 28, 23, 59, 59, TimeSpan.Zero)),
            (BoundaryUserId, new DateTimeOffset(2026, 3, 1, 0, 0, 0, TimeSpan.Zero)),
        ];

        return occurrences
            .Select((occurrence, index) => new SignInEvent(SeedId(index), occurrence.UserId, occurrence.OccurredAt))
            .ToArray();
    }

    private static IEnumerable<(Guid UserId, DateTimeOffset OccurredAt)> SpreadOverMonth(
        Guid userId,
        DateOnly firstDayOfMonth,
        int signInCount)
    {
        var daysInMonth = DateTime.DaysInMonth(firstDayOfMonth.Year, firstDayOfMonth.Month);
        var firstSignInTime = new TimeOnly(9, 0);

        for (var signInNumber = 0; signInNumber < signInCount; signInNumber++)
        {
            var day = firstDayOfMonth.AddDays(signInNumber * daysInMonth / signInCount);
            var time = firstSignInTime.AddMinutes(signInNumber * 7);

            yield return (userId, new DateTimeOffset(day, time, TimeSpan.Zero));
        }
    }

    private static Guid SeedId(int index) => new($"5eed0000-0000-0000-0000-{index + 1:x12}");
}
