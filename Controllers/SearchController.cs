using HotelBookingWebApp.Services;
using HotelBookingWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingWebApp.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly SearchApiService _searchApiService;
        public SearchController(SearchApiService searchApiService)
        {
            _searchApiService = searchApiService;
        }
        [HttpGet("search")]
        public async Task<IActionResult> GetSearchResult(ReservationViewModel model)
        {
            var response = await _searchApiService.FetchSearchResultsAsync(model.CheckIn, model.CheckOut);
            return Json(response);
        }
    }
}
