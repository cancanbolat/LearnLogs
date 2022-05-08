using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            // Loglama
            // appSettings.Development içinden log ayarları yapılabilir. orası Program.cs'i ezer.
            // log seviyesine göre aşağıdaki logları basar.
            _logger.LogTrace("LogTrace -> Get method is called."); //min log seviyesi Trace olsa burası da basılır.
            _logger.LogDebug("LogDebug -> Get method is called.");
            _logger.LogInformation("LogInformation -> Get method is called.");
            _logger.LogWarning("LogWarning -> Get method is called.");
            _logger.LogError("LogError -> Get method is called.");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
