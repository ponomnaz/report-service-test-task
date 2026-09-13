using System.ComponentModel.DataAnnotations;
using ReportService.Api.Contracts;

namespace ReportService.Tests.Contracts;

public sealed class CreateUserStatisticsRequestValidationTests
{
    private static readonly Guid _userId = Guid.Parse("b28d0ced-8af5-4c94-8650-c7946241fd1a");

    [Fact]
    public void ValidRequestHasNoErrors()
    {
        var request = new CreateUserStatisticsRequest(_userId, new DateOnly(2026, 1, 1), new DateOnly(2026, 1, 31));

        Assert.Empty(Validate(request));
    }

    [Fact]
    public void SingleDayPeriodIsValid()
    {
        var request = new CreateUserStatisticsRequest(_userId, new DateOnly(2026, 1, 31), new DateOnly(2026, 1, 31));

        Assert.Empty(Validate(request));
    }

    [Fact]
    public void EmptyUserIdIsReportedUnderItsJsonFieldName()
    {
        var request = new CreateUserStatisticsRequest(Guid.Empty, new DateOnly(2026, 1, 1), new DateOnly(2026, 1, 31));

        var error = Assert.Single(Validate(request));
        Assert.Equal(["user_id"], error.MemberNames);
    }

    [Fact]
    public void ReversedPeriodIsReportedUnderBothJsonFieldNames()
    {
        var request = new CreateUserStatisticsRequest(_userId, new DateOnly(2026, 2, 1), new DateOnly(2026, 1, 31));

        var error = Assert.Single(Validate(request));
        Assert.Equal(["date_from", "date_to"], error.MemberNames);
    }

    [Fact]
    public void AllProblemsAreReportedAtOnce()
    {
        var request = new CreateUserStatisticsRequest(Guid.Empty, new DateOnly(2026, 2, 1), new DateOnly(2026, 1, 31));

        Assert.Equal(2, Validate(request).Count);
    }

    private static List<ValidationResult> Validate(CreateUserStatisticsRequest request)
    {
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(request, new ValidationContext(request), results, validateAllProperties: true);

        return results;
    }
}
