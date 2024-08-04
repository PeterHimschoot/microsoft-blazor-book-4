using BlazorApp.Communication.Client.Entities;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Communication.Client.Services;

public class HttpClientFactoryNamedClient : IWeatherService
{
  private readonly IHttpClientFactory _httpClientFactory;

  public HttpClientFactoryNamedClient(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async ValueTask<WeatherForecast[]> GetForecasts()
  {
    HttpClient httpClient = _httpClientFactory.CreateClient("NamedClient");
    WeatherForecast[]? forcasts =
      await httpClient.GetFromJsonAsync<WeatherForecast[]>("/forecasts");
    return forcasts ?? [];
  }
}
