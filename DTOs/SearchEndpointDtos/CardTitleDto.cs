using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class CardTitleDto
    {
        [JsonPropertyName("string")]
        public string? HotelName { get; set; }
    }
}
