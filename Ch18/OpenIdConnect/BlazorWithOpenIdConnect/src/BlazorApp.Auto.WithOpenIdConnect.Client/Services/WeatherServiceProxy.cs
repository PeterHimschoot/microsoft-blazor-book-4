using BlazorApp.Auto.WithOpenIdConnect.Client.Entities;
using System.Net.Http.Json;

namespace BlazorApp.Auto.WithOpenIdConnect.Client.Services;

public class WeatherServiceProxy : IWeatherService
{
  private readonly HttpClient _httpClient;

  public WeatherServiceProxy(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async ValueTask<IEnumerable<WeatherForecast>> GetForecastsAsync()
  => await _httpClient.GetFromJsonAsync<WeatherForecast[]>("/forecasts") ?? [];
}
