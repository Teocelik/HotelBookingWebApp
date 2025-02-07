using HotelBookingWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingWebApp.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ApiServices _apiService;
        public SearchController(ApiServices apiServices)
        {
            _apiService = apiServices;
        }
        [HttpGet("autoComplete")]
        public async Task<IActionResult> AutoComplete(string query)
        {
            /*burada, autoComplete.js dosyasındaki fetch fonksiyonu ile query parametresi kullanılarak
             kullanıcının girdiği her terime karşılık gelen datayı döner()*/
            var data = await _apiService.FetchAutoCompleteResultsAsync(query);

            return Json(data);
        }
    }
}
