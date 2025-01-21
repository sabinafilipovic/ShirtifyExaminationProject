using ExaminationProject.Services;
using ExaminationProject.ViewModel;

namespace ExaminationProject
{
    public partial class MainPage : ContentPage
    {
        private WeatherService _weatherService = new WeatherService();

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            var city = CityEntry.Text;

            if (!string.IsNullOrEmpty(city))
            {
                var weather = await _weatherService.GetWeatherAsync(city);


                if (weather != null)
                {
                    WeatherLabel.Text = $"Temperatur: {weather.Main.Temp} C\n" +
                            $"Humidity: {weather.Main.Humidity}%\n" +
                            $"Conditions: {weather.Weather[0].Description}";
                }

                else
                {
                    WeatherLabel.Text = "Väderdata inte hittat.";
                }
            }

        }
    }
}
