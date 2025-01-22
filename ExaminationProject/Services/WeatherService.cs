using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ExaminationProject.Model;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;
using System.Diagnostics;

namespace ExaminationProject.Services
{
    public class WeatherService
    {
        private const string ApiKey = "f05c784b0657f4b6aa1e45180499db82";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public async Task<WeatherResponse> GetWeatherByLocationAsync()
        {
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                return null;
            }

            var location = await GetUserLocationAsync();

            if (location != null)
            {
                var url = $"{BaseUrl}?lat={location.Latitude}&lon={location.Longitude}&appid={ApiKey}&units=metric";

                using var client = new HttpClient();
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"📸📸📸📸 API Response: {json}");
                    var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(json);

                    if (weatherResponse?.Main?.Temp != null)
                    {
                        var roundedTemp = Math.Round(weatherResponse.Main.Temp);
                        Debug.WriteLine($"📸📸📸📸📸 UPPVISAD TEMPERATUR {roundedTemp}°C");
                        weatherResponse.Main.Temp = roundedTemp;
                    }

                    return weatherResponse;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private async Task<Location> GetUserLocationAsync()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            return location ?? await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10)));
        }
    }
}
