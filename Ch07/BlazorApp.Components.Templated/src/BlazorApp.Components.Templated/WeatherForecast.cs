namespace BlazorApp.Components.Templated;

public class WeatherForecast
{
  public DateOnly Date { get; set; }
  public int TemperatureC { get; set; }
  public string? Summary { get; set; }
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class BelgianWeatherForecast
{
  public DateOnly Date { get; set; }
  public int TemperatureC { get; set; }
  public string? Summary { get; set; }
  public int TemperatureF 
  => (TemperatureC > 0) 
     ? 32 + (int)(TemperatureC / 0.5556)
     : throw new Exception("Too cold!");
}