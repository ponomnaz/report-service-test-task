using System.Text.Json;
using ReportService.Api.Contracts;

namespace ReportService.Tests.Contracts;

public sealed class UserStatisticsContractTests
{
    private static readonly JsonSerializerOptions _apiJsonOptions =
        new JsonSerializerOptions(JsonSerializerDefaults.Web).ConfigureForApi();

    [Fact]
    public void CreateRequestIsReadFromSnakeCaseJson()
    {
        const string Json = """{"user_id":"b28d0ced-8af5-4c94-8650-c7946241fd1a","date_from":"2026-01-01","date_to":"2026-01-31"}""";

        var request = JsonSerializer.Deserialize<CreateUserStatisticsRequest>(Json, _apiJsonOptions);

        var expected = new CreateUserStatisticsRequest(
            Guid.Parse("b28d0ced-8af5-4c94-8650-c7946241fd1a"),
            new DateOnly(2026, 1, 1),
            new DateOnly(2026, 1, 31));
        Assert.Equal(expected, request);
    }

    [Theory]
    [InlineData("""{"date_from":"2026-01-01","date_to":"2026-01-31"}""")]
    [InlineData("""{"user_id":"b28d0ced-8af5-4c94-8650-c7946241fd1a","date_to":"2026-01-31"}""")]
    [InlineData("""{"user_id":"b28d0ced-8af5-4c94-8650-c7946241fd1a","date_from":"2026-01-01"}""")]
    public void CreateRequestWithMissingFieldIsRejected(string json)
    {
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<CreateUserStatisticsRequest>(json, _apiJsonOptions));
    }

    [Fact]
    public void CreateRequestAcceptsIsoDateTimesForDates()
    {
        const string Json = """{"user_id":"b28d0ced-8af5-4c94-8650-c7946241fd1a","date_from":"2026-01-01T00:00:00Z","date_to":"2026-01-31T23:59:59+03:00"}""";

        var request = JsonSerializer.Deserialize<CreateUserStatisticsRequest>(Json, _apiJsonOptions);

        Assert.Equal(new DateOnly(2026, 1, 1), request!.DateFrom);
        Assert.Equal(new DateOnly(2026, 1, 31), request.DateTo);
    }

    [Fact]
    public void CreatedRequestIdIsWrittenAsBareJsonString()
    {
        var requestId = Guid.Parse("1a98b57d-e090-4d18-8654-678e463b73e8");

        var json = JsonSerializer.Serialize(requestId, _apiJsonOptions);

        Assert.Equal("\"1a98b57d-e090-4d18-8654-678e463b73e8\"", json);
    }
}
