using BlazorApp.WASMInteractivity.Components;

namespace BlazorApp.WASMInteractivity;
public class Program
{
  public static void Main(string[] args)
  {
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    _ = builder.Services.AddRazorComponents()
        .AddInteractiveWebAssemblyComponents();

    WebApplication app = builder.Build();

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
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

    app.Run();
  }
}
