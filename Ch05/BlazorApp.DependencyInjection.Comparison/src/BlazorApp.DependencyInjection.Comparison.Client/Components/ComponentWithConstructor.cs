using BlazorApp.DependencyInjection.Comparison.Client.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.DependencyInjection.Comparison.Client.Components;

public class ComponentWithConstructor : ComponentBase
{
  private readonly ISingletonService _service;

  public ComponentWithConstructor(ISingletonService service)
  {
    _service = service;
  }
}
