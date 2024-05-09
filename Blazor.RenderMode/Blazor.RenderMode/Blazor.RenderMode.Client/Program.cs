using Blazor.Utils;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Blazor.RenderMode.Client;

internal class Program
{
  private static async Task Main(string[] args)
  {
    WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
    _ = builder.Services.AddScoped<ActiveCircuitState>();
    builder.Services.AddTransient<RenderModeProvider>();

    await builder.Build().RunAsync();
  }
}
