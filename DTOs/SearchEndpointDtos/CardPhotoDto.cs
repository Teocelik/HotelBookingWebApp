using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class CardPhotoDto
    {
        [JsonPropertyName("sizes")]
        public ImageDto? images { get; set; }
    }
}
