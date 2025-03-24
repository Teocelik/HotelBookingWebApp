using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class ImageDto
    {
        [JsonPropertyName("urlTemplate")]
        public string? UrlTemplate { get; set; }
    }
}
