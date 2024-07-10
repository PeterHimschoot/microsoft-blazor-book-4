using BlazorApp.UsinggRPC.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient(nameof(IWeatherService), httpClient =>
  httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddScoped<IWeatherService, WeatherServiceProxy>();

await builder.Build().RunAsync();
