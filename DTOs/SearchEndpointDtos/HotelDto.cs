using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class HotelDto
    {
        //Otel ismi
        [JsonPropertyName("cardTitle")]
        public CardTitleDto? HotelName { get; set; }
        //Otel görseli

        //Otel fiyatı
        [JsonPropertyName("commerceInfo")]
        public CommerceInfoDto? CommerceInfo { get; set; }
    }
}
