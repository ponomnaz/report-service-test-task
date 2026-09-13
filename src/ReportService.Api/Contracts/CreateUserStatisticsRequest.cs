namespace ReportService.Api.Contracts;

public sealed record CreateUserStatisticsRequest(Guid UserId, DateOnly DateFrom, DateOnly DateTo);
