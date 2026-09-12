using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportService.Api.Domain;
using ReportService.Api.Infrastructure.Persistence.Seed;

namespace ReportService.Api.Infrastructure.Persistence.Configurations;

internal sealed class SignInEventConfiguration : IEntityTypeConfiguration<SignInEvent>
{
    public void Configure(EntityTypeBuilder<SignInEvent> builder)
    {
        builder.HasKey(signIn => signIn.Id);

        builder.Property(signIn => signIn.Id).ValueGeneratedNever();
        builder.Property(signIn => signIn.UserId);
        builder.Property(signIn => signIn.OccurredAt);

        builder.HasIndex(signIn => new { signIn.UserId, signIn.OccurredAt });

        builder.HasData(DemoSignInEvents.All);
    }
}
