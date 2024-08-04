using BlazorApp.Communication.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.Services.AddScoped(sp => new HttpClient {
//  BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
//});

//builder.Services.AddHttpClient("NamedClient", httpClient =>
//{
//  httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
//});

builder.Services.AddHttpClient<WeatherServiceProxy>(httpClient =>
{
  httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddScoped<IWeatherService, WeatherServiceProxy>();

await builder.Build().RunAsync();
