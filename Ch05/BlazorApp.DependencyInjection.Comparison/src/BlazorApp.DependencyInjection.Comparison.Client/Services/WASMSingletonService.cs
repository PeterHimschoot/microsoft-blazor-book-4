namespace BlazorApp.DependencyInjection.Comparison.Client.Services;

public class WASMSingletonService : ISingletonService, IDisposable
{
  public Guid Guid { get; set; } = Guid.NewGuid();

  public void Dispose()
  => Console.WriteLine("WASMSingletonService Disposed");
}