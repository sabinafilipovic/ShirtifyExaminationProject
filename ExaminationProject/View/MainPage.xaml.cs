using ExaminationProject.Services;
using ExaminationProject.ViewModel;

namespace ExaminationProject
{
    public partial class MainPage : ContentPage
    {
        private WeatherService _weatherService;

        public MainPage(MainViewModel vm, WeatherService weatherService)
        {
            InitializeComponent();
            BindingContext = vm;
            _weatherService = weatherService;

            GetWeatherAutomatically();
        }

        private async Task GetWeatherAutomatically()
        {
            try
            {
                var weather = await _weatherService.GetWeatherByLocationAsync();

                if (weather != null)
                {
                    WeatherLabel.Text = $"Temperatur: {weather.Main.Temp} °C | Väder: {weather.Weather[0].Description}";
                }
                else
                {
                    WeatherLabel.Text = "Kunde inte hämta väderinformation.";
                }
            }
            catch (Exception ex)
            {
                WeatherLabel.Text = $"⚠️ Fel vid hämtning av väder: {ex.Message}";
            }
        }
    }
}
