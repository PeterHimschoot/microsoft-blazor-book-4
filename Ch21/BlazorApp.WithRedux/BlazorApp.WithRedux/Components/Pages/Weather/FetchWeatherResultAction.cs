using BlazorApp.WithRedux.Entities;

namespace BlazorApp.WithRedux.Components.Pages.Weather;

public record FetchWeatherResultAction(WeatherForecast[]? Forecasts);

