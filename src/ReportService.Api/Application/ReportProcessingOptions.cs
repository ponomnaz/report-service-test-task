using System.ComponentModel.DataAnnotations;

namespace ReportService.Api.Application;

public sealed class ReportProcessingOptions
{
    public const string SectionName = "ReportProcessing";
    public const int DefaultProcessingDurationMs = 60_000;

    [Range(1, int.MaxValue, ErrorMessage = "ReportProcessing:ProcessingDurationMs must be a positive number of milliseconds.")]
    public int ProcessingDurationMs { get; init; } = DefaultProcessingDurationMs;

    public TimeSpan ProcessingDuration => TimeSpan.FromMilliseconds(ProcessingDurationMs);
}
