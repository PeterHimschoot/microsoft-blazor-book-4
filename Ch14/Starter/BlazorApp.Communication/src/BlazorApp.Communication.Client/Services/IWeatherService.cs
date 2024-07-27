using BlazorApp.Communication.Client.Entities;

namespace BlazorApp.Communication.Client.Services;

public interface IWeatherService
{
  ValueTask<WeatherForecast[]> GetForecasts();
}
