namespace BlazorApp.StateManagement.WASM.Entities;

public class State
{
  public Dictionary<string, int> values = new();

  public int this[string key]
  {
    get
    {

      if (values.TryGetValue(key, out int value))
      {
        return value;

      }
      return 0;
    }
    set {
      values[key] = value;
    }
  }
}
