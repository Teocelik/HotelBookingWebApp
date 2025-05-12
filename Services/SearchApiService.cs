using HotelBookingWebApp.DTOs.SearchEndpointDtos;
using HotelBookingWebApp.Models;
using Microsoft.Extensions.Options;

namespace HotelBookingWebApp.Services
{
    public class SearchApiService
    {
        //fields
        private readonly HttpClient _httpClient;
        private readonly SearchEndpointSetting _searchEndpointSetting;
        //constructor
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
        public async Task<string> FetchSearchResultsAsync(int geoId, string checkIn, string checkOut, int adult, int child)
        {
            //request atalım
            var response = await _httpClient.GetAsync($"?geoId={geoId}&checkIn={checkIn}&checkOut={checkOut}&adults={adult}&children={child}");

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception($"API hatası: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
