using BlazorApp.WithRedux.Components;
using BlazorApp.WithRedux.Components.Pages.Weather;
using BlazorApp.WithRedux.Stores;
using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();

    builder.Services.AddFluxor(options =>
    {
      options.ScanAssemblies(typeof(AppStore).Assembly);
#if DEBUG
      options.UseReduxDevTools();
#endif
    });

    builder.Services.AddScoped<WeatherService>();

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
  }
}