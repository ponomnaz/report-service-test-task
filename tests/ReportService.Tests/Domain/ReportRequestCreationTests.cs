using ReportService.Api.Domain;

namespace ReportService.Tests.Domain;

public sealed class ReportRequestCreationTests
{
    private static readonly Guid _userId = Guid.Parse("b28d0ced-8af5-4c94-8650-c7946241fd1a");
    private static readonly DateRange _period = new(new DateOnly(2026, 1, 1), new DateOnly(2026, 1, 31));
    private static readonly DateTimeOffset _createdAt = new(2026, 2, 1, 12, 0, 0, TimeSpan.Zero);

    [Fact]
    public void NewRequestIsPendingWithoutResult()
    {
        var request = ReportRequest.Create(_userId, _period, _createdAt);

        Assert.Equal(ReportRequestStatus.Pending, request.Status);
        Assert.Null(request.CountSignIn);
        Assert.Null(request.CompletedAt);
    }

    [Fact]
    public void NewRequestKeepsGivenParameters()
    {
        var request = ReportRequest.Create(_userId, _period, _createdAt);

        Assert.Equal(_userId, request.UserId);
        Assert.Equal(_period, request.Period);
        Assert.Equal(_createdAt, request.CreatedAt);
    }

    [Fact]
    public void EachNewRequestGetsItsOwnId()
    {
        var first = ReportRequest.Create(_userId, _period, _createdAt);
        var second = ReportRequest.Create(_userId, _period, _createdAt);

        Assert.NotEqual(Guid.Empty, first.Id);
        Assert.NotEqual(first.Id, second.Id);
    }

    [Fact]
    public void CreateRejectsEmptyUserId()
    {
        Assert.Throws<ArgumentException>(() => ReportRequest.Create(Guid.Empty, _period, _createdAt));
    }
}
