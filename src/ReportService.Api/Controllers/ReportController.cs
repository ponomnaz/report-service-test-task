using System.ComponentModel.DataAnnotations;
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
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInfoAsync(
        [FromQuery, Required] Guid? query,
        CancellationToken cancellationToken)
    {
        var info = await reportRequestService.GetInfoAsync(query!.Value, cancellationToken);

        return info is null ? NotFound() : Ok(ReportInfoResponse.From(info));
    }
}
