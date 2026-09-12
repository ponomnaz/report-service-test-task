namespace ReportService.Api.Domain;

public sealed record DateRange
{
    public DateRange(DateOnly from, DateOnly to)
    {
        if (from > to)
        {
            throw new ArgumentException($"Range start {from:yyyy-MM-dd} is after range end {to:yyyy-MM-dd}.", nameof(to));
        }

        From = from;
        To = to;
    }

    public DateOnly From { get; }

    public DateOnly To { get; }
}
