using BlazorApp.Auto.WithOpenIdConnect.Client.Entities;
using BlazorApp.Auto.WithOpenIdConnect.Client.Services;

namespace BlazorApp.Auto.WithOpenIdConnect.Services;

public class WeatherService : IWeatherService, IExternalWeatherService
{
  static string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
  public ValueTask<IEnumerable<WeatherForecast>> GetForecastsAsync()
  {
    DateOnly startDate = DateOnly.FromDateTime(DateTime.Now);
    IEnumerable<WeatherForecast> forecasts = 
    Enumerable.Range(1, 5)
              .Select(index => new WeatherForecast
    {
      Date = startDate.AddDays(index),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = summaries[Random.Shared.Next(summaries.Length)]
    });
    return ValueTask.FromResult(forecasts);
  }
}