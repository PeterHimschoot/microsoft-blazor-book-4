using BlazorApp.AutoInteractivity.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp.AutoInteractivity.Client;

internal class Program
{
  static async Task Main(string[] args)
  {
    var builder = WebAssemblyHostBuilder.CreateDefault(args);

    builder.Services.AddTransient<RenderModeProvider>();
    builder.Services.AddScoped<ActiveCircuitState>();

    await builder.Build().RunAsync();
  }
}
