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
            //var içerik = await response.Content.ReadAsStringAsync();
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception($"API hatası: {response.StatusCode}");
            }
            return await response.Content.ReadAsStringAsync();
        }
    }
}
