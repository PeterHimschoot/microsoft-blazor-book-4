using BlazorApp.UsinggRPC.Client.Services;
using Grpc.Net.Client.Web;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient(nameof(IWeatherService), httpClient =>
  httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// builder.Services.AddScoped<IWeatherService, WeatherServiceProxy>();

builder.Services.AddScoped<IWeatherService, ForecastGrpcService>();

builder.Services.AddScoped(services =>
 {
   IConfiguration config =
   services.GetRequiredService<IConfiguration>();
   string backEndUrl = config["gRPC:weatherServices"]!;
   var httpHandler =
   new GrpcWebHandler(GrpcWebMode.GrpcWebText,
   new HttpClientHandler());
   return GrpcChannel.ForAddress(backEndUrl,
   new GrpcChannelOptions { HttpHandler = httpHandler });
 });
await builder.Build().RunAsync();
