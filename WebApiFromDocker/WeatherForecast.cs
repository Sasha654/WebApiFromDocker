using System;

namespace WebApiFromDocker
{
    public class WeatherForecast
    {
        public WeatherForecast(string city, DateTime dateTimeUtc, int temperatureC)
        {
            City = city.ToUpper();
            DateTimeUtc = dateTimeUtc;
            TemperatureC = temperatureC;
        }

        public DateTime DateTimeUtc { get; }

        public int TemperatureC { get; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string City { get; }
    }
}
