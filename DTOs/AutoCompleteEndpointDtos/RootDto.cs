using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    //Bu class, API'den dönen data'yı temsil edecek!
    [JsonSerializable(typeof(RootDto))]
    public class RootDto
    {
        [JsonPropertyName("data")]
        public List<AutoCompleteItemDto>? Data { get; set; }
        [JsonPropertyName("status")]
        public bool Status { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
