namespace ReportService.Api.Contracts;

public sealed record UserStatisticsResponse(Guid UserId, int CountSignIn);
