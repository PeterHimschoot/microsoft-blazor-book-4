using BlazorApp.Testing.Entities;

namespace BlazorApp.Testing.Services;

public interface IWeatherService
{
  ValueTask<WeatherForecast[]?> GetForecasts();
}
