using System.Text.Json;
using ReportService.Api.Contracts;

namespace ReportService.Tests.Contracts;

public sealed class LenientDateOnlyJsonConverterTests
{
    private static readonly JsonSerializerOptions _options = new() { Converters = { new LenientDateOnlyJsonConverter() } };

    [Theory]
    [InlineData("\"2026-01-31\"")]
    [InlineData("\"2026-01-31T00:00:00Z\"")]
    [InlineData("\"2026-01-31T23:59:59Z\"")]
    [InlineData("\"2026-01-31T01:30:00+03:00\"")]
    [InlineData("\"2026-01-31T23:30:00-05:00\"")]
    public void ReadsCalendarDateAsWrittenByClient(string json)
    {
        var date = JsonSerializer.Deserialize<DateOnly>(json, _options);

        Assert.Equal(new DateOnly(2026, 1, 31), date);
    }

    [Theory]
    [InlineData("\"31.01.2026\"")]
    [InlineData("\"2026-02-30\"")]
    [InlineData("\"not a date\"")]
    [InlineData("20260131")]
    [InlineData("null")]
    public void RejectsAnythingThatIsNotIsoDateOrDateTime(string json)
    {
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DateOnly>(json, _options));
    }

    [Fact]
    public void WritesDateInIsoFormat()
    {
        var json = JsonSerializer.Serialize(new DateOnly(2026, 1, 31), _options);

        Assert.Equal("\"2026-01-31\"", json);
    }
}
