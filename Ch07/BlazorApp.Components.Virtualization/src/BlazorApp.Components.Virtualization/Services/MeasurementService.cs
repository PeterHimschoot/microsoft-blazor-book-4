using BlazorApp.Components.Virtualization.Data;

namespace BlazorApp.Components.Virtualization.Services;

public class MeasurementsService
{
  public ValueTask<List<Measurement>> GetMeasurements()
  {
    const int nrOfRows = 1000;
    List<Measurement> result = new ();
    for (int i = 0; i < nrOfRows; i += 1)
    {
      result.Add(new Measurement()
      {
        Row = i,
        Guid = Guid.NewGuid(), 
        Min = Random.Shared.Next(0, 100),
        Avg = Random.Shared.Next(100, 300),
        Max = Random.Shared.Next(300, 400),
      });
    }
    return ValueTask.FromResult(result);
  }

  public async ValueTask<(List<Measurement>, int)> GetMeasurementsPage(int from, int count, CancellationToken cancellationToken)
  {
    const int maxMeasurements = 1000;
    // Start Add delay to emulate database access
    const int delay = 50;
    await Task.Delay(delay, cancellationToken);
    // End Add delay
    var result = new List<Measurement>();
    var rnd = new Random();
    count = Math.Max(0, Math.Min(count, maxMeasurements - from));
    for (int i = 0; i < count; i += 1)
    {
      result.Add(new Measurement()
      {
        Row = i,
        Guid = Guid.NewGuid(),
        Min = rnd.Next(0, 100),
        Avg = rnd.Next(100, 300),
        Max = from + i //rnd.Next(300, 400),
      });
    }
    return (result, maxMeasurements);
  }
}