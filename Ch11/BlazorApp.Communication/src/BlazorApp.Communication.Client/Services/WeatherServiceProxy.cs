using BlazorApp.Communication.Client.Entities;
using System.Net.Http.Json;

namespace BlazorApp.Communication.Client.Services;

public class WeatherServiceProxy : IWeatherService
{
  private readonly HttpClient _httpClient;

  public WeatherServiceProxy(HttpClient httpClient) 
  => _httpClient = httpClient;

  public async ValueTask<WeatherForecast[]> GetForecasts()
  {
    WeatherForecast[]? forecasts =
      await _httpClient.GetFromJsonAsync<WeatherForecast[]>("/forecasts");
    return forecasts!;
  }
}
