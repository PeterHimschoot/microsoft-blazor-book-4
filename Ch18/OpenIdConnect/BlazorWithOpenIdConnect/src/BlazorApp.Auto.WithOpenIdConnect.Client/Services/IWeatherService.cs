using BlazorApp.Auto.WithOpenIdConnect.Client.Entities;

namespace BlazorApp.Auto.WithOpenIdConnect.Client.Services;

public interface IWeatherService
{
  ValueTask<IEnumerable<WeatherForecast>> GetForecastsAsync();
}
