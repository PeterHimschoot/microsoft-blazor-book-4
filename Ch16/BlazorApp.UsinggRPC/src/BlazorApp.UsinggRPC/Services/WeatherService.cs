using BlazorApp.UsinggRPC.Client.Entities;
using BlazorApp.UsinggRPC.Client.Services;
using Google.Protobuf;

namespace BlazorApp.UsinggRPC.Services;

public class WeatherService : IWeatherService
{
  private readonly ImageService imageService;

  public WeatherService(ImageService imageService)
  => this.imageService = imageService;

  public async ValueTask<WeatherForecast[]> GetForecasts()
  {
    // Simulate asynchronous loading to demonstrate a loading indicator
    await Task.Delay(500);

    var startDate = DateOnly.FromDateTime(DateTime.Now);
    var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
    WeatherForecast[] forecasts = Enumerable.Range(1, 250).Select(index => new WeatherForecast
    {
      Date = startDate.AddDays(index),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = summaries[Random.Shared.Next(summaries.Length)],
      Image = imageService.RandomImage()

    }).ToArray();

    return forecasts;
  }
}
