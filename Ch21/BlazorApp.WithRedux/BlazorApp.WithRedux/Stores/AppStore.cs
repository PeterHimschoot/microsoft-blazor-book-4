using BlazorApp.WithRedux.Entities;

namespace BlazorApp.WithRedux.Stores;

public record AppStore(
    int ClickCounter,
    bool IsLoading,
    WeatherForecast[]? Forecasts
    );

