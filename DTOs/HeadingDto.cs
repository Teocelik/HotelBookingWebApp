using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs
{
    public class HeadingDto
    {
        [JsonPropertyName("htmlString")]
        public string? HtmlString { get; set; }
    }
}
