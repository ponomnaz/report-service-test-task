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
builder.Services.ConfigureHttpJsonOptions(json => json.SerializerOptions.ConfigureForApi());
builder.Services.AddOpenApi();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(swagger => swagger.SwaggerEndpoint("/openapi/v1.json", "Report Service"));
}

app.MapControllers();
app.MapHealthChecks("/health");

app.Services.GetRequiredService<IStartupValidator>().Validate();
await app.MigrateDatabaseAsync();

await app.RunAsync();
