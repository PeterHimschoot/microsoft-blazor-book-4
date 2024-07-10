using BlazorApp.UsinggRPC.Client.Entities;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.UsinggRPC.Client.Services;

public class WeatherServiceProxy : IWeatherService
{
  private readonly IHttpClientFactory _httpClientFactory;

  public WeatherServiceProxy(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async ValueTask<WeatherForecast[]> GetForecasts()
  {
    HttpClient httpClient = _httpClientFactory.CreateClient(nameof(IWeatherService));
    WeatherForecast[]? forecasts = 
      await httpClient.GetFromJsonAsync<WeatherForecast[]>("/forecasts");
    return forecasts!;
  }
}
