using BlazorApp.PetHotel.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.PetHotel.Data;

public static class AnimalMetadata
{
  private static Dictionary<string, object> ToParameters(this object instance)
    => new Dictionary<string, object>
      {
        [nameof(DynamicComponent.Instance)] = instance
      };

  public static ComponentMetadata? ToMetadata(this AnimalKind animal)
  => animal switch
  {
    AnimalKind.Dog => new ComponentMetadata(typeof(DogComponent), new Dog().ToParameters()),
    AnimalKind.Cat => new ComponentMetadata(typeof(CatComponent), new Cat().ToParameters()),
    _ => null
  };
}
