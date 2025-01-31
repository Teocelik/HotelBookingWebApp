using System.Diagnostics;
using HotelBookingWebApp.Models;
using HotelBookingWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApiServices _apiServices;

        public HomeController(ILogger<HomeController> logger, ApiServices apiServices)
        {
            _logger = logger;
            _apiServices = apiServices;
        }

        public async Task<IActionResult> Index()
        {
            await _apiServices.GetAutoComplete("turkiye");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
