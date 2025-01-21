using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ExaminationProject.Model;

namespace ExaminationProject.Services
{
    public class WeatherService
    {
        private const string ApiKey = "f05c784b0657f4b6aa1e45180499db82";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            using var client = new HttpClient();
            var url = $"{BaseUrl}?={city}&appid={ApiKey}&units=metric";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResponse>(json);
            }
            else
            {
                return null;
            }
        }

    }
}
