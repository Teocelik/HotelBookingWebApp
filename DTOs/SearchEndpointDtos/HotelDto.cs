using HotelBookingWebApp.ViewModels;
using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class HotelDto
    {
        [JsonPropertyName("cardTitle")]
        public CardTitleDto? CardTitle { get; set; }
        //Otel görselleri tutan liste
        [JsonPropertyName("cardPhotos")]
        public List<CardPhotoDto>? CardPhotos { get; set; }
        //Otel fiyatı
        [JsonPropertyName("commerceInfo")]
        public CommerceInfoDto? CommerceInfo { get; set; }
    }
}
