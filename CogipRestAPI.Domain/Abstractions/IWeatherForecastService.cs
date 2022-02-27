using CogipRestAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogipRestAPI.Domain.Abstractions
{
    public interface IWeatherForecastService
    {
        List<WeatherForecast> ProcessFTemperature();
    }
}
