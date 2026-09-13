using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReportService.Api.Contracts;

public sealed class LenientDateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private const string DateFormat = "yyyy-MM-dd";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String && reader.TryGetDateTimeOffset(out var dateTime))
        {
            return DateOnly.FromDateTime(dateTime.DateTime);
        }

        throw new JsonException("Expected a date in yyyy-MM-dd format or an ISO 8601 date-time.");
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
}
