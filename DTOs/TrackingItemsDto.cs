using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs
{
    public class TrackingItemsDto
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
