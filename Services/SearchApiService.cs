using HotelBookingWebApp.Models;
using Microsoft.Extensions.Options;

namespace HotelBookingWebApp.Services
{
    public class SearchApiService
    {
        //fields
        private readonly HttpClient _httpClient;
        private readonly SearchEndpointSetting _searchEndpointSetting;

        public SearchApiService(HttpClient httpClient, IOptions<SearchEndpointSetting> searchEndpointSetting)
        {
            _httpClient = httpClient;
            _searchEndpointSetting = searchEndpointSetting.Value;

            //base adres ve headerları ayarlayalım.
            _httpClient.BaseAddress = new Uri(_searchEndpointSetting.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", _searchEndpointSetting.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", _searchEndpointSetting.ApiHost);
        }

        //Search işlemi sonrası gelecek olan data'yı karşılayalım
        //public async Task<string> FetchSearchResultsAsync(string query)
        //{
        //    //request atalıp
        //    var response = await _httpClient.GetAsync($"?geoId={}")
        //}
    }
}
