using BlazorApp.DependencyInjection.Comparison.Client.Services;

namespace BlazorApp.DependencyInjection.Comparison.Services;

public class SRScopedService : IScopedService, IDisposable
{
  public Guid Guid { get; set; } = Guid.NewGuid();

  public void Dispose()
    => Console.WriteLine("SRScopedService Disposed");
}