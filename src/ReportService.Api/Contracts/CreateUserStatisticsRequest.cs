using System.ComponentModel.DataAnnotations;

namespace ReportService.Api.Contracts;

public sealed record CreateUserStatisticsRequest(Guid UserId, DateOnly DateFrom, DateOnly DateTo) : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var userIdField = JsonName(nameof(UserId));
        var dateFromField = JsonName(nameof(DateFrom));
        var dateToField = JsonName(nameof(DateTo));

        if (UserId == Guid.Empty)
        {
            yield return new ValidationResult($"{userIdField} must not be empty.", [userIdField]);
        }

        if (DateFrom > DateTo)
        {
            yield return new ValidationResult(
                $"{dateFromField} must not be later than {dateToField}.",
                [dateFromField, dateToField]);
        }
    }

    private static string JsonName(string propertyName) => ApiJsonSerialization.NamingPolicy.ConvertName(propertyName);
}
