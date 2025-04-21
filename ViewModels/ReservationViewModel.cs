using HotelBookingWebApp.DTOs.SearchEndpointDtos;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingWebApp.ViewModels
{
    public class ReservationViewModel
    {
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int Adult { get; set; }
        public int Kid { get; set; }
        public List<HotelDto> Hotels { get; set; }
        
        public int GeoId { get; set; } // bu hidden input'a bağlanacak(.cshtml kısmı)
    }
}
