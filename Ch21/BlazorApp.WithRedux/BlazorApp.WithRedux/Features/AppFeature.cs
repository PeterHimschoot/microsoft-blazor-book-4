using BlazorApp.WithRedux.Stores;
using Fluxor;

namespace BlazorApp.WithRedux.Features;
public class AppFeature : Feature<AppStore>
{
  public override string GetName()
  => nameof(AppStore);

  protected override AppStore GetInitialState()
  => new(
    ClickCounter: 0,
    IsLoading: false,
    Forecasts: []
    );
}