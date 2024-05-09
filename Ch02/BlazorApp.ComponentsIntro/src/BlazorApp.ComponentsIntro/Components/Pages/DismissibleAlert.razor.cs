using Microsoft.AspNetCore.Components;

namespace BlazorApp.ComponentsIntro.Components.Pages;

public partial class DismissibleAlert
{
  [Parameter]
  public bool Show { get; set; }

  [Parameter]
  public RenderFragment ChildContent { get; set; } = default!;

  public void Dismiss()
  => Show = false;
}
