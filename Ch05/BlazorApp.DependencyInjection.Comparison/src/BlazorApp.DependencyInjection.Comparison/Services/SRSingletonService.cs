using BlazorApp.DependencyInjection.Comparison.Client.Services;

namespace BlazorApp.DependencyInjection.Comparison.Services;

public class SRSingletonService : ISingletonService, IDisposable
{
  public Guid Guid { get; set; } = Guid.NewGuid();

  public void Dispose()
  => Console.WriteLine("SRSingletonService Disposed");
}