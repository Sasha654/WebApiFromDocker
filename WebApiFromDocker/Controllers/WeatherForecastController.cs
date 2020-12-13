using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApiFromDocker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private RandomWeatherService _weather;
        private RedisRepository _cache;

        public WeatherForecastController(
            RandomWeatherService weather, 
            RedisRepository cache)
        {
            _weather = weather;
            _cache = cache;
        }

        //GET /api/weatherforecast/moscow
        [HttpGet("{city}")]
        public async Task<WeatherForecast> GetAsync(string city)
        {
            int temperatureC;
            var cachedTemperatureCString = await _cache.GetValue(city);

            if (!string.IsNullOrEmpty(cachedTemperatureCString))
            {
                temperatureC = Convert.ToInt32(cachedTemperatureCString);
            }
            else
            {
                temperatureC = _weather.GetForecast(city);
                await _cache.SetValue(city, temperatureC.ToString());
            }

            var forecast = new WeatherForecast(city, DateTime.UtcNow, temperatureC);
            return forecast;
        }
    }
}
