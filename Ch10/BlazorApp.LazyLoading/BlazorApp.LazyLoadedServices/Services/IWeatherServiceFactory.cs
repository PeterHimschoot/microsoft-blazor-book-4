namespace BlazorApp.LazyLoadedServices.Services;

public interface IWeatherServiceFactory
{
  IWeatherService Create();
}
