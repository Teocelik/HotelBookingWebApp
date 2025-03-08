using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    public class SearchItemDto
    {
        public List<HotelDto>? Hotels { get; set; }
    }
}
