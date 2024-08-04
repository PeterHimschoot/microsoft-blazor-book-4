using BlazorApp.Communication.Client.Entities;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Communication.Client.Services;

public class HttpClientFactoryBasicUsage : IWeatherService
{
  private readonly IHttpClientFactory _httpClientFactory;

  public HttpClientFactoryBasicUsage(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async ValueTask<WeatherForecast[]> GetForecasts()
  {
    HttpClient httpClient = _httpClientFactory.CreateClient();
    WeatherForecast[]? forcasts =
      await httpClient.GetFromJsonAsync<WeatherForecast[]>("/forecasts");
    return forcasts ?? [];
  }

}
