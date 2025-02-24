using System.Text.Json.Serialization;

namespace HotelBookingWebApp.DTOs.SearchEndpointDtos
{
    //Bu class, API'den dönen datanın(dizi) her bir elemanını temsil edecek!
    public class AutoCompleteItemDto
    {
        public int GeoId { get; set; }  // geoId

        public HeadingDto? Heading { get; set; }
        public secondaryTextLineOneDto? SecondaryTextLineOne { get; set; }

        public TrackingItemsDto? TrackingItems { get; set; }
    }
}
