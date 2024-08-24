using BlazorApp.WithRedux.Entities;

namespace BlazorApp.WithRedux.Components.Pages.Weather;

public class WeatherService
{
  static string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

  public async Task<WeatherForecast[]> GetForecastsAsync()
  {
    // Simulate asynchronous loading to demonstrate a loading indicator
    await Task.Delay(5000);

    var startDate = DateOnly.FromDateTime(DateTime.Now);
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
      Date = startDate.AddDays(index),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = summaries[Random.Shared.Next(summaries.Length)]
    }).ToArray();
  }
}
