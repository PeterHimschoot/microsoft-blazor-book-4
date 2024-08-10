using BlazorApp.PizzaPlace.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp.PizzaPlace.Shared;
internal class Program
{
  private static async Task Main(string[] args)
  {
    WebAssemblyHostBuilder builder = 
      WebAssemblyHostBuilder.CreateDefault(args);

    builder.Services.AddScoped<State>();

    // ADD HttpClient configuration
    builder.Services.AddHttpClient(nameof(MenuServiceProxy),
    httpClient =>
    {
      httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    });

    builder.Services.AddHttpClient<OrderMenuProxy>(
    httpClient =>
    {
      httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    });

    builder.Services
     .AddScoped<IMenuService, MenuServiceProxy>()  // UPDATE CLASS
     .AddScoped<IOrderService, OrderMenuProxy>();

    await builder.Build().RunAsync();
  }
}
