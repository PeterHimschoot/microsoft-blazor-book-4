namespace BlazorApp.DependencyInjection.Comparison.Client.Services;

public class WASMTransientService : ITransientService, IDisposable
{
  public Guid Guid { get; set; } = Guid.NewGuid();

  public void Dispose()
  => Console.WriteLine("WASMTransientService Disposed");
}
