using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace BlazorApp.AutoInteractivity.Components;

public class RenderModeProvider(ActiveCircuitState activeCircuitState)
{
  public string GetRenderMode(ComponentBase page)
  {
    if (OperatingSystem.IsBrowser())
    {
      return RenderModes.InteractiveWebAssembly;
    }
    else if (activeCircuitState.CircuitExists)
    {
      return RenderModes.InteractiveServer;
    }
    else if (UsesStaticRendering(page))
    {
      return RenderModes.ServerStaticStreamed;
    }
    return RenderModes.ServerStatic;
  }

  private bool UsesStaticRendering(ComponentBase page)
  => UsesStaticRendering(page.GetType());

  private bool UsesStaticRendering(Type pageType)
  => pageType.GetCustomAttribute<StreamRenderingAttribute>() is not null;
}
