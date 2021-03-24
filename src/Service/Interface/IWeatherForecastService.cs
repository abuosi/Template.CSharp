using Domain;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecastDomain> Get();
    }
}
