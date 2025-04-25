using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class CtaDto
    {
        /*Otelin kendi sayfasının bulunduğu url'yi temsil edecek property
         */
        [JsonPropertyName("externalUrl")]
        public string? ExternalUrl { get; set; }
    }
}
