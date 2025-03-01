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
        private readonly AutoCompleteItemDto _autoCompleteItemDto;
        public SearchApiService(HttpClient httpClient, IOptions<SearchEndpointSetting> searchEndpointSetting, AutoCompleteItemDto autoCompleteItemDto)
        {
            _httpClient = httpClient;
            _searchEndpointSetting = searchEndpointSetting.Value;
            _autoCompleteItemDto = autoCompleteItemDto;
            //base adres ve headerları ayarlayalım.
            _httpClient.BaseAddress = new Uri(_searchEndpointSetting.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", _searchEndpointSetting.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", _searchEndpointSetting.ApiHost);
        }

        //Search işlemi sonrası gelecek olan data'yı karşılayalım
        public async Task<string> FetchSearchResultsAsync(string checkIn, string checkOut)
        {
            //geoId değerini alalım(tıklanılan bölgenin değeridir)
            var geoId = _autoCompleteItemDto.GeoId;
            //request atalıp
            var response = await _httpClient.GetAsync($"?geoId={geoId}&checkIn={checkIn}&checkOut={checkOut}");

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception($"API hatası: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
