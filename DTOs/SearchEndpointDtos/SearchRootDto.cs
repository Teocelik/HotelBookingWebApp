using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    //Search endpointinden dönen data'yı temsil edecek class!
    [JsonSerializable(typeof(SearchRootDto))]
    public class SearchRootDto
    {
        [JsonPropertyName("data")]
        public SearchItemDto? Data { get; set; }
        [JsonPropertyName("status")]
        public bool Status { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}