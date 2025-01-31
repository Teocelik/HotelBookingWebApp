using HotelBookingWebApp.Models;
using Microsoft.Extensions.Options;

namespace HotelBookingWebApp.Services
{
    public class ApiServices
    {
        //API kullanmak için field(alan) (HttpClient ve ApiSettings sınıflarını) fields olarak ekleyelim
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public ApiServices(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;

            //Base adres ve headerları varsayılan olarak ayarlayalım.
            _httpClient.BaseAddress = new Uri(_apiSettings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiSettings.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _apiSettings.ApiHost);
        }

        //Kullanıcı bir terimi girince, o terime için anlık sorgu yaparak response dönecek sınıf oluştur.
        public async Task<string> GetAutoComplete(string query)
        {
            //request atıp response alalım()
            var response = await _httpClient.GetAsync($"?query=hotels%2F{Uri.EscapeDataString(query)}");
            response.EnsureSuccessStatusCode();

            var icerikControl = await response.Content.ReadAsStringAsync();
            return icerikControl;
        }


    }
}
