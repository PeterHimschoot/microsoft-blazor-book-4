using BlazorApp.UsinggRPC.Client.Entities;
using BlazorApp.UsinggRPC.Client.Pages;
using BlazorApp.UsinggRPC.Client.Services;
using BlazorApp.UsinggRPC.Components;
using BlazorApp.UsinggRPC.Services;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddSingleton<ImageService>();
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseWebAssemblyDebugging();
}
else
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseGrpcWeb();

app.MapGrpcService<WeatherForecastProtoService>()
   .EnableGrpcWeb();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp.UsinggRPC.Client._Imports).Assembly);

app.MapGet("/forecasts", async (IWeatherService weatherService) =>
{
  WeatherForecast[] forecasts = await weatherService.GetForecasts();
  return forecasts;
});

app.Run();
