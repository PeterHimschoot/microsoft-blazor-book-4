using BlazorApp.Testing.Entities;
using BlazorApp.Testing.Services;

namespace BlazorApp.Testing.Tests;

internal class WeatherServiceStub : IWeatherService
{
  public required WeatherForecast[]? FakeForecasts { get; set; }

  public ValueTask<WeatherForecast[]?> GetForecasts()
  => ValueTask.FromResult(FakeForecasts);
}
