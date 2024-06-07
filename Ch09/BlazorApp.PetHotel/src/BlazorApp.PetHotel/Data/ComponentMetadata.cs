namespace BlazorApp.PetHotel.Data;

public class ComponentMetadata
{
  public ComponentMetadata(Type type, Dictionary<string, object> parameters)
  {
    Type = type;
    Parameters = parameters;
  }

  public Type Type { get; set; }

  public Dictionary<string, object> Parameters { get; }
}