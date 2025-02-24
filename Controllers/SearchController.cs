using HotelBookingWebApp.DTOs.SearchEndpointDtos;
using HotelBookingWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HotelBookingWebApp.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly AutoCompleteApiService _apiService;
        public SearchController(AutoCompleteApiService apiServices)
        {
            _apiService = apiServices;
        }
        [HttpGet("autoComplete")]
        public async Task<IActionResult> AutoComplete(string query)
        {
            /*burada, autoComplete.js dosyasındaki fetch fonksiyonu ile query parametresi kullanılarak
             kullanıcının girdiği her terime karşılık gelen datayı döner()*/
            var response = await _apiService.FetchAutoCompleteResultsAsync(query);

            //API'den gelen datayı map edip, AutoCompleteItemDto'ya dönüştürelim.
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Küçük-büyük harf duyarlılığını kaldır
            };

            var autoCompleteResponse = JsonSerializer.Deserialize<RootDto>(response, options);

            return Json(autoCompleteResponse);
        }
    }
}
