using BlazorApp.AutoInteractivity.Components;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace BlazorApp.AutoInteractivity;
public class Program
{
  public static void Main(string[] args)
  {
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    _ = builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents()
        .AddInteractiveWebAssemblyComponents();

    builder.Services.AddScoped<ActiveCircuitState>();
    builder.Services.AddScoped(typeof(CircuitHandler), typeof(ActiveCircuitHandler));
    builder.Services.AddTransient<RenderModeProvider>();

    WebApplication app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseWebAssemblyDebugging();
    }
    else
    {
      _ = app.UseExceptionHandler("/Error");
      _ = app.UseHsts();
    }

    _ = app.UseHttpsRedirection();

    _ = app.UseStaticFiles();
    _ = app.UseAntiforgery();

    _ = app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode()
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

    app.Run();
  }
}
