using HotelBookingWebApp.DTOs.SearchEndpointDtos;
using HotelBookingWebApp.Services;
using HotelBookingWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HotelBookingWebApp.Controllers
{
    //[Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly SearchApiService _searchApiService;
        public SearchController(SearchApiService searchApiService)
        {
            _searchApiService = searchApiService;
        }
        //[HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] int geoId, ReservationViewModel? model)
        {
            //NOT: AutoComplete endpointi ile API'den gelen geoId değerini js. ile bu endpoint'e gönderdim.

            /*Kullanıcı, CheckIn ve CheckOut tarihleri girmediği durumlarda deafult olarak
           * şimdiki tarihten iki gün sonrasını alsın.*/
            DateTime checkIn = model.CheckIn ?? DateTime.Now.AddDays(1);
            DateTime checkOut = model.CheckOut ?? DateTime.Now.AddDays(2);
            
            var response = await _searchApiService.FetchSearchResultsAsync(geoId, checkIn.ToString("yyyy-MM-dd"), checkOut.ToString("yyyy-MM-dd"));

            //API'den gelen datayı map edip, SearchResponseDto'ya dönüştürelim.
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Küçük-büyük harf duyarlılığını kaldır
            };

            var searchResponse = JsonSerializer.Deserialize<SearchRootDto>(response, options);
            var list = searchResponse?.Data?.Hotels ?? new List<HotelDto>();
            return View(list);
        }
    }
}
