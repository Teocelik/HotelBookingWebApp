using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class CommerceInfoDto
    {
        [JsonPropertyName("string")]
        public PriceForDisplayDto? Price { get; set; }
    }
}
