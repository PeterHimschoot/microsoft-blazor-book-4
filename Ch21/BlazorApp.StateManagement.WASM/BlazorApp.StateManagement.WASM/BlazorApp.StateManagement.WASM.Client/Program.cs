using BlazorApp.StateManagement.WASM.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

internal class Program
{
  private static async global::System.Threading.Tasks.Task Main(string[] args)
  {
    var builder = WebAssemblyHostBuilder.CreateDefault(args);

    builder.Services.AddScoped<LocalStorage>();

    builder.Services.AddHttpClient<StateService>(
    httpClient =>
    {
      httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    }
    );

    await builder.Build().RunAsync();
  }
}