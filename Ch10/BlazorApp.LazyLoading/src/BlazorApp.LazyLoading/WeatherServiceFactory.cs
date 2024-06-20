using BlazorApp.LazyLoadedServices.Services;
using BlazorApp.LazyLoading.Services;

namespace BlazorApp.LazyLoading;

public class WeatherServiceFactory : IWeatherServiceFactory
{
  private readonly HttpClient _http;

  public WeatherServiceFactory(HttpClient http) 
  => _http = http;

  public IWeatherService Create()
  => new WeatherService(_http);
}
