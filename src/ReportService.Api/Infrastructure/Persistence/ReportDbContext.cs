using Microsoft.EntityFrameworkCore;
using ReportService.Api.Domain;

namespace ReportService.Api.Infrastructure.Persistence;

public sealed class ReportDbContext(DbContextOptions<ReportDbContext> options) : DbContext(options)
{
    public DbSet<ReportRequest> ReportRequests => Set<ReportRequest>();

    public DbSet<SignInEvent> SignInEvents => Set<SignInEvent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReportDbContext).Assembly);
}
