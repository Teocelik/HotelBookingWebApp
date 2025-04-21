using HotelBookingWebApp.DTOs.SearchEndpointDtos;
using HotelBookingWebApp.Services;
using HotelBookingWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HotelBookingWebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchApiService _searchApiService;
        public SearchController(SearchApiService searchApiService)
        {
            _searchApiService = searchApiService;
        }

        public async Task<IActionResult> Search(ReservationViewModel? viewModel)
        {
            //NOT: AutoComplete endpointi ile API'den gelen geoId değerini js. ile bu endpoint'e gönderdim.

            /*Kullanıcı, CheckIn ve CheckOut tarihleri girmediği durumlarda deafult olarak
           * şimdiki tarihten iki gün sonrasını alsın.*/

            int geoId = viewModel.GeoId;
            DateTime checkIn = viewModel?.CheckIn ?? DateTime.Now.AddDays(1);
            DateTime checkOut = viewModel?.CheckOut ?? DateTime.Now.AddDays(2);
            int adult = viewModel?.Adult ?? 0;
            int children = viewModel?.Kid ?? 0;

            var response = await _searchApiService.FetchSearchResultsAsync(geoId, checkIn.ToString("yyyy-MM-dd"),
                checkOut.ToString("yyyy-MM-dd"), adult, children);

            //API'den gelen datayı map edip, SearchResponseDto'ya dönüştürelim.
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Küçük-büyük harf duyarlılığını kaldır
            };

            var searchResponse = JsonSerializer.Deserialize<SearchRootDto>(response, options);
            viewModel.Hotels = searchResponse?.Data?.Hotels ?? new List<HotelDto>();

            return View(viewModel);
        }
    }
}
