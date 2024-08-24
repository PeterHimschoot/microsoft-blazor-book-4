using BlazorApp.Auto.WithOpenIdConnect.Client.Entities;

namespace BlazorApp.Auto.WithOpenIdConnect.Client.Services;

public interface IExternalWeatherService
{
  ValueTask<IEnumerable<WeatherForecast>> GetForecastsAsync();
}
