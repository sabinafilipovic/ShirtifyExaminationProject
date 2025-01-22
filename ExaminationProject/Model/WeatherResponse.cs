namespace ExaminationProject.Model
{
    public class WeatherResponse
    {
        public Main Main { get; set; }
        public Weather[] Weather { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Humidity { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
    }
}
