using System.Text.Json;

namespace ReportService.Api.Contracts;

public static class JsonSerializerOptionsExtensions
{
    public static JsonSerializerOptions ConfigureForApi(this JsonSerializerOptions options)
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;

        return options;
    }
}
