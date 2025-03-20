using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class imageDto
    {
        [JsonPropertyName("urlTemplate")]
        public string? UrlTemplate { get; set; }
    }
}
