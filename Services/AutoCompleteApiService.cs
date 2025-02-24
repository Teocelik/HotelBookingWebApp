using HotelBookingWebApp.DTOs;
using HotelBookingWebApp.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace HotelBookingWebApp.Services
{
    public class AutoCompleteApiService
    {
        //API kullanmak için field(alan) (HttpClient ve ApiSettings sınıflarını) fields olarak ekleyelim
        private readonly HttpClient _httpClient;
        private readonly AutoCompleteEndpointSetting _apiSettings;

        public AutoCompleteApiService(HttpClient httpClient, IOptions<AutoCompleteEndpointSetting> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;

            //Base adres ve headerları ayarlayalım.
            _httpClient.BaseAddress = new Uri(_apiSettings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiSettings.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RaidAPI-Host", _apiSettings.ApiHost);
        }

        //js dosyasındaki "autoComplete.js" içindeki js kodları ile dinamik olarak çalışır(Fetch metodu ile)
        public async Task<string> FetchAutoCompleteResultsAsync(string query)
        {
            //request atıp response alalım()
            var response = await _httpClient.GetAsync($"?query={Uri.EscapeDataString(query)}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API hatası: {response.StatusCode}");
            }

            var içerik = await response.Content.ReadAsStringAsync();

            return içerik;
        }
    }
}
