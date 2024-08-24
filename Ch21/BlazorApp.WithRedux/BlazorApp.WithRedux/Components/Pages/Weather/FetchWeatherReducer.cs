using BlazorApp.WithRedux.Stores;
using Fluxor;

namespace BlazorApp.WithRedux.Components.Pages.Weather;

public class FetchWeatherReducer
{
  [ReducerMethod]
  public static AppStore ReduceFetchWeatherAction(
    AppStore state, FetchWeatherAction action)
    => state with { IsLoading = true };

  [ReducerMethod]
  public static AppStore ReduceFetchWeatherResultAction(
    AppStore state, FetchWeatherResultAction action)
    => state with { IsLoading = false, Forecasts = action.Forecasts };

}
