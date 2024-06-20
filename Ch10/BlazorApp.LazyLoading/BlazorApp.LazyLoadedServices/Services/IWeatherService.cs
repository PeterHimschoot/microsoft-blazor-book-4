using static System.Net.WebRequestMethods;

namespace BlazorApp.LazyLoadedServices.Services;

public interface IWeatherService
{
  ValueTask<WeatherForecast[]?> GetForecastsAsync();
}
