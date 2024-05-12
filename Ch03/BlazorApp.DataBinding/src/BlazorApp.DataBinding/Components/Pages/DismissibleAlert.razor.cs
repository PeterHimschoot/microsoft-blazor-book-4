using Microsoft.AspNetCore.Components;

namespace BlazorApp.DataBinding.Components.Pages;

public partial class DismissibleAlert
{
  [Parameter]
  public bool Show { get; set; }

  [Parameter]
  public required EventCallback<bool> ShowChanged { get; set; }

  [Parameter]
  public RenderFragment ChildContent { get; set; } = default!;

  private async Task UpdateShow(bool value)
  {
    if (value != Show)
    {
      await ShowChanged.InvokeAsync(value);
    }
  }

  public async Task Dismiss()
  => await UpdateShow(false);
}
