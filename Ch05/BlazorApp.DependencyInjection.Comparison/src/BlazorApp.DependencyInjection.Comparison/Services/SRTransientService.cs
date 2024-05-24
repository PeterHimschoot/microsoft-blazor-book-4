using BlazorApp.DependencyInjection.Comparison.Client.Services;

namespace BlazorApp.DependencyInjection.Comparison.Services;

public class SRTransientService : ITransientService, IDisposable
{
  public Guid Guid { get; set; } = Guid.NewGuid();

  public void Dispose()
  => Console.WriteLine("TransientService Disposed");
}
