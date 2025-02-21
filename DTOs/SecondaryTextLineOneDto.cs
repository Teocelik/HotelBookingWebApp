using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs
{
    public class secondaryTextLineOneDto
    {
        [JsonPropertyName("string")]
        public string? StringValue { get; set; }
    }
}
