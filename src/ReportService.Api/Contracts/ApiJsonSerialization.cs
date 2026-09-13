using System.Text.Json;

namespace ReportService.Api.Contracts;

public static class ApiJsonSerialization
{
    public static JsonNamingPolicy NamingPolicy { get; } = JsonNamingPolicy.SnakeCaseLower;

    public static JsonSerializerOptions ConfigureForApi(this JsonSerializerOptions options)
    {
        options.PropertyNamingPolicy = NamingPolicy;
        options.RespectRequiredConstructorParameters = true;
        options.Converters.Add(new LenientDateOnlyJsonConverter());

        return options;
    }
}
