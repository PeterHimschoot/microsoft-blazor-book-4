namespace BlazorApp.UsingLayouts;

public static class Countries
{
  public static Dictionary<string, string> All { get; } = new()
  {
    ["us"] = "United States",
    ["ca"] = "Canada",
    ["uk"] = "United Kingdom",
    ["be"] = "Belgium"
  };
}