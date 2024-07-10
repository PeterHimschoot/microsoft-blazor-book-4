using BlazorApp.UsinggRPC.Client.Entities;

namespace BlazorApp.UsinggRPC.Client.Services;

public interface IWeatherService
{
  ValueTask<WeatherForecast[]> GetForecasts();
}
