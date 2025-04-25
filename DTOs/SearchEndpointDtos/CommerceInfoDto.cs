using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class CommerceInfoDto
    {
        [JsonPropertyName("priceForDisplay")]
        public PriceForDisplayDto? PriceForDisplay { get; set; }

        [JsonPropertyName("cta")]
        public CtaDto? Cta { get; set; }
    }
}
