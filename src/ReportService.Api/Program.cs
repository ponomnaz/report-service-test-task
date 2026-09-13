using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Options;
using ReportService.Api.Application;
using ReportService.Api.Contracts;
using ReportService.Api.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services
    .AddControllers(mvc =>
    {
        mvc.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
        mvc.ModelMetadataDetailsProviders.Add(
            new SystemTextJsonValidationMetadataProvider(ApiJsonSerialization.NamingPolicy));
    })
    .AddJsonOptions(json => json.JsonSerializerOptions.ConfigureForApi());
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

app.MapControllers();

app.Services.GetRequiredService<IStartupValidator>().Validate();
await app.MigrateDatabaseAsync();

await app.RunAsync();
