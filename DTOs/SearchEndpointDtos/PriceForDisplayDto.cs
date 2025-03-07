using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class PriceForDisplayDto
    {
        [JsonPropertyName("string")]
        public string? Price { get; set; }
    }
}
