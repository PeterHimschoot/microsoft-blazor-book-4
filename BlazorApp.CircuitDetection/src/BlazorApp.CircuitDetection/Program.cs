using BlazorApp.CircuitDetection.Components;
using BlazorApp.CircuitDetection.Providers;
using Microsoft.AspNetCore.Components.Server.Circuits;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<LoggingCircuitHandler>();
builder.Services.AddSingleton<CircuitHandler>(
  (provider)=>provider.GetRequiredService<LoggingCircuitHandler>());
builder.Services.AddScoped<CurrentCircuitHandler>();
builder.Services.AddScoped<CircuitHandler>(
  (provider) => provider.GetRequiredService<CurrentCircuitHandler>());

builder.Services.AddIdleCircuitHandler(options =>
  options.IdleTimeout = TimeSpan.FromSeconds(5));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
