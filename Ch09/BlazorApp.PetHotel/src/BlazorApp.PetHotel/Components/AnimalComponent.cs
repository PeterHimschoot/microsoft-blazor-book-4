using Microsoft.AspNetCore.Components;

namespace BlazorApp.PetHotel.Components;

public class AnimalComponent : ComponentBase
{
  [Parameter]
  public EventCallback ValidSubmit { get; set; }
}