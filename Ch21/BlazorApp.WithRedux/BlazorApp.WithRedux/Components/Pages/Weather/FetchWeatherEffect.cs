using BlazorApp.WithRedux.Entities;
using Fluxor;

namespace BlazorApp.WithRedux.Components.Pages.Weather;

public class FetchWeatherEffect : Effect<FetchWeatherAction>
{
  private readonly WeatherService _weatherService;

  public FetchWeatherEffect(WeatherService weatherService)
  {
    _weatherService = weatherService;
  }

  public override async Task HandleAsync
    (FetchWeatherAction action, IDispatcher dispatcher)
  {
    WeatherForecast[]? forecasts = await _weatherService.GetForecastsAsync();
    dispatcher.Dispatch(new FetchWeatherResultAction(forecasts));
  }
}