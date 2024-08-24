using BlazorApp.WithRedux.Stores;
using Fluxor;

namespace BlazorApp.WithRedux.Components.Pages.Counter;

public static class CounterReducer
{
  [ReducerMethod]
  public static AppStore ReduceIncrementCounterAction(
      AppStore state, IncrementCounterAction action)
      => state with { ClickCounter = state.ClickCounter + 1 };
}
