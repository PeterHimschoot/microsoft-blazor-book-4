using BlazorApp.Communication.Client.Entities;
using BlazorApp.Communication.Client.Services;

namespace BlazorApp.Communication.Services;

public class WeatherService : IWeatherService
{
  public async ValueTask<WeatherForecast[]> GetForecasts()
  {
    // Simulate asynchronous loading from database
    await Task.Delay(500);

    DateOnly startDate = DateOnly.FromDateTime(DateTime.Now);
    string[] summaries = [
      "Freezing", "Bracing", "Chilly",
      "Cool", "Mild", "Warm", "Balmy",
      "Hot", "Sweltering", "Scorching"
      ];
    WeatherForecast[] forecasts = 
    Enumerable.Range(1, 5)
              .Select(index => new WeatherForecast
    {
      Date = startDate.AddDays(index),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = summaries[Random.Shared.Next(summaries.Length)]
    }).ToArray();

    return forecasts;
  }
}