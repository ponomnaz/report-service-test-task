using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportService.Api.Domain;

namespace ReportService.Api.Infrastructure.Persistence.Configurations;

internal sealed class ReportRequestConfiguration : IEntityTypeConfiguration<ReportRequest>
{
    private const int StatusMaxLength = 16;

    public void Configure(EntityTypeBuilder<ReportRequest> builder)
    {
        builder.HasKey(request => request.Id);

        builder.Property(request => request.Id).ValueGeneratedNever();
        builder.Property(request => request.UserId);
        builder.Property(request => request.CreatedAt);

        builder.ComplexProperty(request => request.Period, period =>
        {
            period.Property(range => range.From);
            period.Property(range => range.To);
        });

        builder.Property(request => request.Status)
            .HasConversion<string>()
            .HasMaxLength(StatusMaxLength);

        builder.Property<uint>("Version").IsRowVersion();

        builder.HasIndex(request => new { request.Status, request.CreatedAt });
    }
}
