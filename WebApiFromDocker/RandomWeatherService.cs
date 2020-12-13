using System;

namespace WebApiFromDocker
{
    public class RandomWeatherService
    {
        private Random _randomGenerator;

        public RandomWeatherService()
        {
            _randomGenerator = new Random();
        }

        public int GetForecast(string city)
        {
            var length = city.Length;
            var temperatureC = _randomGenerator.Next(-length, length);
            return temperatureC;
        }
    }
}
