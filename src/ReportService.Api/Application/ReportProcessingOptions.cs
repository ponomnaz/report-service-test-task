using System.ComponentModel.DataAnnotations;

namespace ReportService.Api.Application;

public sealed class ReportProcessingOptions
{
    public const string SectionName = "ReportProcessing";
    public const int DefaultProcessingDurationMs = 60_000;
    public const int DefaultPollingIntervalMs = 1_000;

    [Range(1, int.MaxValue, ErrorMessage = "ReportProcessing:ProcessingDurationMs must be a positive number of milliseconds.")]
    public int ProcessingDurationMs { get; init; } = DefaultProcessingDurationMs;

    [Range(1, int.MaxValue, ErrorMessage = "ReportProcessing:PollingIntervalMs must be a positive number of milliseconds.")]
    public int PollingIntervalMs { get; init; } = DefaultPollingIntervalMs;

    public TimeSpan ProcessingDuration => TimeSpan.FromMilliseconds(ProcessingDurationMs);

    public TimeSpan PollingInterval => TimeSpan.FromMilliseconds(PollingIntervalMs);
}
