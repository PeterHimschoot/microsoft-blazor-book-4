using BlazorApp.LazyLoadedServices;
using BlazorApp.LazyLoadedServices.Services;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorApp.LazyLoading.Services;

public class WeatherService : IWeatherService
{
  private readonly HttpClient _http;

  public WeatherService(HttpClient http)
  {
    _http = http;
  }


  public async ValueTask<WeatherForecast[]?> GetForecastsAsync()
  {
    return await _http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
  }
}
