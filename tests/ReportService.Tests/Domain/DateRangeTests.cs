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
}
