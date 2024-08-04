using BlazorApp.Communication.Client.Entities;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Communication.Client.Services;

public class WhyHttpClientFactory : IWeatherService
{
  public async ValueTask<WeatherForecast[]> GetForecasts()
  {
    using HttpClient httpClient = new();
    WeatherForecast[]? forcasts =
      await httpClient.GetFromJsonAsync<WeatherForecast[]>("/forecasts");
    return forcasts ?? [];
  }



}
