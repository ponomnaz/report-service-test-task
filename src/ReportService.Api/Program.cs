using Microsoft.Extensions.Options;
using ReportService.Api.Application;
using ReportService.Api.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

app.MapControllers();

app.Services.GetRequiredService<IStartupValidator>().Validate();
await app.MigrateDatabaseAsync();

await app.RunAsync();
