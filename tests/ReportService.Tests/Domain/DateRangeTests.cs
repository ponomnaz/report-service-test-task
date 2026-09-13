using ReportService.Api.Domain;

namespace ReportService.Tests.Domain;

public sealed class DateRangeTests
{
    [Fact]
    public void RangeOfSingleDayIsValid()
    {
        var day = new DateOnly(2026, 3, 1);

        var range = new DateRange(day, day);

        Assert.Equal(day, range.From);
        Assert.Equal(day, range.To);
    }

    [Fact]
    public void RangeRejectsStartAfterEnd()
    {
        var from = new DateOnly(2026, 3, 2);
        var to = new DateOnly(2026, 3, 1);

        Assert.Throws<ArgumentException>(() => new DateRange(from, to));
    }

    [Fact]
    public void RangesWithSameBoundsAreEqual()
    {
        var first = new DateRange(new DateOnly(2026, 1, 1), new DateOnly(2026, 1, 31));
        var second = new DateRange(new DateOnly(2026, 1, 1), new DateOnly(2026, 1, 31));

        Assert.Equal(first, second);
    }

    [Fact]
    public void RangeStartsAtUtcMidnightOfFirstDay()
    {
        var february = new DateRange(new DateOnly(2026, 2, 1), new DateOnly(2026, 2, 28));

        Assert.Equal(new DateTimeOffset(2026, 2, 1, 0, 0, 0, TimeSpan.Zero), february.StartUtc);
    }

    [Fact]
    public void RangeEndsAtUtcMidnightAfterLastDay()
    {
        var february = new DateRange(new DateOnly(2026, 2, 1), new DateOnly(2026, 2, 28));

        Assert.Equal(new DateTimeOffset(2026, 3, 1, 0, 0, 0, TimeSpan.Zero), february.EndUtcExclusive);
    }

    [Fact]
    public void SingleDayRangeSpansExactlyOneDay()
    {
        var day = new DateOnly(2026, 3, 1);

        var range = new DateRange(day, day);

        Assert.Equal(TimeSpan.FromDays(1), range.EndUtcExclusive - range.StartUtc);
    }
}
