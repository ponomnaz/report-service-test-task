using Microsoft.AspNetCore.Mvc;
using ReportService.Api.Application;
using ReportService.Api.Contracts;
using ReportService.Api.Domain;

namespace ReportService.Api.Controllers;

[ApiController]
[Route("report")]
public sealed class ReportController(ReportRequestService reportRequestService) : ControllerBase
{
    [HttpPost("user_statistics")]
    [ProducesResponseType<CreateUserStatisticsResponse>(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> CreateUserStatisticsAsync(
        CreateUserStatisticsRequest request,
        CancellationToken cancellationToken)
    {
        var period = new DateRange(request.DateFrom, request.DateTo);
        var requestId = await reportRequestService.CreateAsync(request.UserId, period, cancellationToken);

        return Accepted(new CreateUserStatisticsResponse(requestId));
    }
}
