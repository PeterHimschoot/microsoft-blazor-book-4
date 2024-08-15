using System.Runtime.InteropServices;
using WeatherAPI;

namespace BlazorApp.Server.WithOpenIdConnect.Services;

public class WeatherService
{
  private readonly IHttpClientFactory _httpClientFactory;

  public WeatherService(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async ValueTask<WeatherForecast[]> GetForecastsAsync()
  {
    HttpClient httpClient =
      _httpClientFactory.CreateClient(nameof(WeatherService));
    WeatherForecast[]? result =
      await httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
    return result ?? [];
  }
}
