using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class HeadingDto
    {
        [JsonPropertyName("htmlString")]
        public string? HtmlString { get; set; }
    }
}
