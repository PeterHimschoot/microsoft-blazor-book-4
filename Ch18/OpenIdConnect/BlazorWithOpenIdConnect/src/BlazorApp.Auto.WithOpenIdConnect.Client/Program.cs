using BlazorApp.Auto.WithOpenIdConnect.Client;
using BlazorApp.Auto.WithOpenIdConnect.Client.Policies;
using BlazorApp.Auto.WithOpenIdConnect.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

internal class Program
{
  private static async global::System.Threading.Tasks.Task Main(string[] args)
  {
    var builder = WebAssemblyHostBuilder.CreateDefault(args);

    builder.Services.AddAuthorizationCore(options => {
      options.AddPolicy(Policies.FromBelgium, Policies.FromBelgiumAuthorizationPolicy());
    });
    builder.Services.AddCascadingAuthenticationState();
    builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

    // Services for Weather component when running in browser

    builder.Services.AddHttpClient<IWeatherService, WeatherServiceProxy>(
      httpClient =>
      {
        httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
      });

    builder.Services.AddHttpClient<IExternalWeatherService, ExternalWeatherServiceProxy>(
      httpClient =>
      {
        httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
      });

    await builder.Build().RunAsync();
  }
}