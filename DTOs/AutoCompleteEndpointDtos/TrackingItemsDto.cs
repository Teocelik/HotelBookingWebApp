using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class TrackingItemsDto
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
