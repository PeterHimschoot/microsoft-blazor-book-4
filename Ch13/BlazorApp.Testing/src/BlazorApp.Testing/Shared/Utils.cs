namespace BlazorApp.Testing.Shared;

public class Utils
{
  public int Square(int i)
  {
    checked // Check for overflow
    {
      return i * i;
    }
  }

}
