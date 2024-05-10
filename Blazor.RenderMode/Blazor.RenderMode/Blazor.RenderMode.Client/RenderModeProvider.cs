using Blazor.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Reflection;

namespace Blazor.RenderMode;

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

  public bool IsInteractive(ComponentBase page)
  => GetRenderMode(page) switch
  {
    RenderModes.InteractiveWebAssembly => true,
    RenderModes.InteractiveServer => true,
    _ => false
  };

  private bool UsesStaticRendering(ComponentBase page)
  => UsesStaticRendering(page.GetType());

  private bool UsesStaticRendering(Type pageType)
  => pageType.GetCustomAttribute<StreamRenderingAttribute>() is not null;

}
