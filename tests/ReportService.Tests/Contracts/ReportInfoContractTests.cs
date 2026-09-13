using System.Text.Json;
using ReportService.Api.Application;
using ReportService.Api.Contracts;

namespace ReportService.Tests.Contracts;

public sealed class ReportInfoContractTests
{
    private static readonly JsonSerializerOptions _apiJsonOptions =
        new JsonSerializerOptions(JsonSerializerDefaults.Web).ConfigureForApi();

    private static readonly Guid _taskExampleQuery = Guid.Parse("1a98b57d-e090-4d18-8654-678e463b73e8");
    private static readonly Guid _taskExampleUserId = Guid.Parse("b28d0ced-8af5-4c94-8650-c7946241fd1a");

    [Theory]
    [InlineData(50, """{"query":"1a98b57d-e090-4d18-8654-678e463b73e8","percent":50,"result":null}""")]
    [InlineData(75, """{"query":"1a98b57d-e090-4d18-8654-678e463b73e8","percent":75,"result":null}""")]
    public void InProgressInfoMatchesTaskExample(int percent, string expectedJson)
    {
        var info = new ReportRequestInfo(_taskExampleQuery, percent, Result: null);

        var json = JsonSerializer.Serialize(ReportInfoResponse.From(info), _apiJsonOptions);

        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void CompletedInfoMatchesTaskExample()
    {
        var info = new ReportRequestInfo(_taskExampleQuery, 100, new UserStatistics(_taskExampleUserId, 12));

        var json = JsonSerializer.Serialize(ReportInfoResponse.From(info), _apiJsonOptions);

        Assert.Equal(
            """{"query":"1a98b57d-e090-4d18-8654-678e463b73e8","percent":100,"result":{"user_id":"b28d0ced-8af5-4c94-8650-c7946241fd1a","count_sign_in":12}}""",
            json);
    }
}
