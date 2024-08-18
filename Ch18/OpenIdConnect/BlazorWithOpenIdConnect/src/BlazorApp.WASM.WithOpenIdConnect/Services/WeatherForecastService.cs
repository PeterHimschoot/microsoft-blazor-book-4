using System.Net.Http.Json;

namespace BlazorApp.WASM.WithOpenIdConnect.Services;

public class WeatherForecastService
{
  private readonly IHttpClientFactory _httpClientFactory;

  public WeatherForecastService(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async ValueTask<WeatherForecast[]> GetForecastsAsync()
  {
    HttpClient httpClient =
      _httpClientFactory.CreateClient(nameof(WeatherForecastService));
    WeatherForecast[]? result =
      await httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
    return result ?? [];
  }
}
