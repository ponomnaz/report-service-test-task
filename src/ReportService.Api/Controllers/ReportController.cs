using Microsoft.AspNetCore.Mvc;
using ReportService.Api.Application;
using ReportService.Api.Contracts;
using ReportService.Api.Domain;

namespace ReportService.Api.Controllers;

[ApiController]
[Route("report")]
public sealed class ReportController(ReportRequestService reportRequestService) : ControllerBase
{
    private const string GetInfoRouteName = "GetReportInfo";

    [HttpPost("user_statistics")]
    [ProducesResponseType<CreateUserStatisticsResponse>(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> CreateUserStatisticsAsync(
        CreateUserStatisticsRequest request,
        CancellationToken cancellationToken)
    {
        var period = new DateRange(request.DateFrom, request.DateTo);
        var requestId = await reportRequestService.CreateAsync(request.UserId, period, cancellationToken);

        return AcceptedAtRoute(GetInfoRouteName, new { query = requestId }, new CreateUserStatisticsResponse(requestId));
    }

    [HttpGet("info", Name = GetInfoRouteName)]
    [ProducesResponseType<ReportInfoResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInfoAsync([FromQuery] Guid query, CancellationToken cancellationToken)
    {
        var info = await reportRequestService.GetInfoAsync(query, cancellationToken);

        return info is null ? NotFound() : Ok(ReportInfoResponse.From(info));
    }
}
