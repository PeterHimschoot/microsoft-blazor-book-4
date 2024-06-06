namespace BlazorApp.Components.Virtualization.Data;

public class Measurement
{
  public required int Row { get; init; }
  public required Guid Guid { get; init; }
  public required double Min { get; init; }
  public required double Avg { get; init; }
  public required double Max { get; init; }
}
