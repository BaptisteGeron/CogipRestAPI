using CogipRestAPI.Dal;
using CogipRestAPI.Domain.Abstractions;
using CogipRestAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CogipRestAPI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _service;
        private readonly DataContext _ctx;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service, DataContext ctx)
        {
            _logger = logger;
            _service = service;
            _ctx = ctx;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _service.ProcessFTemperature();
        }

        
    }
}