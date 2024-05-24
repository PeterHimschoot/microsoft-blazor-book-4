namespace BlazorApp.DependencyInjection.Comparison.Client.Services;

public class WASMScopedService : IScopedService, IDisposable
{
  public Guid Guid { get; set; } = Guid.NewGuid();

  public void Dispose()
    => Console.WriteLine("WASMScopedService Disposed");
}