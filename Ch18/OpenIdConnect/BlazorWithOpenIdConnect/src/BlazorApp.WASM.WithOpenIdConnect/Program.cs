using BlazorApp.Policies;
using BlazorApp.WASM.WithOpenIdConnect;
using BlazorApp.WASM.WithOpenIdConnect.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

internal class Program
{
  private static async global::System.Threading.Tasks.Task Main(string[] args)
  {
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    builder.Services.AddScoped(sp => new HttpClient
    {
      BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

    builder.Services.AddOidcAuthentication(options =>
    {
      // Configure your authentication provider options here.
      // For more information, see https://aka.ms/blazor-standalone-auth
      builder.Configuration.Bind("oidc", options.ProviderOptions);
      options.UserOptions.RoleClaim = "role";
    });

    builder.Services.AddHttpClient<WeatherForecastService>(
    client =>
      client.BaseAddress = new Uri("https://localhost:5005")
    )
    .AddHttpMessageHandler(handlerConfig =>
    {
      AuthorizationMessageHandler handler =
      handlerConfig.GetRequiredService<AuthorizationMessageHandler>()
      .ConfigureHandler(
        authorizedUrls: ["https://localhost:5005"],
        scopes: ["u2uApi"]
        );
      return handler;
    })
    ;

    builder.Services.AddSingleton<WeatherForecastService>();

    builder.Services.AddAuthorizationCore(options =>
    {
      options.AddPolicy(Policies.FromBelgium,
        Policies.FromBelgiumPolicy());
    });

    await builder.Build().RunAsync();
  }
}