using Blazor.RenderMode.Client.Pages;
using Blazor.RenderMode.Components;
using Blazor.Utils;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace Blazor.RenderMode;
public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents()
        .AddInteractiveWebAssemblyComponents();

    builder.Services.AddScoped<ActiveCircuitState>();
    builder.Services.AddScoped(typeof(CircuitHandler), typeof(ActiveCircuitHandler));
    builder.Services.AddTransient<RenderModeProvider>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseWebAssemblyDebugging();
    }
    else
    {
      app.UseExceptionHandler("/Error");
      // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode()
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

    app.Run();
  }
}
