using BlazorApp.Auto.WithOpenIdConnect;
using BlazorApp.Auto.WithOpenIdConnect.Client.Entities;
using BlazorApp.Auto.WithOpenIdConnect.Client.Pages;
using BlazorApp.Auto.WithOpenIdConnect.Client.Policies;
using BlazorApp.Auto.WithOpenIdConnect.Client.Services;
using BlazorApp.Auto.WithOpenIdConnect.Components;
using BlazorApp.Auto.WithOpenIdConnect.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    //builder.WebHost.ConfigureKestrel(options =>
    //{
    //  options.ConfigureHttpsDefaults(httpsOptions =>
    //  {
    //    // Lower HTTPS for decryption
    //    httpsOptions.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
    //  });
    //});

    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents()
        .AddInteractiveWebAssemblyComponents();

    builder.Services.AddAuthentication(options =>
    {
      options.DefaultScheme =
        CookieAuthenticationDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme =
        OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme,
      options =>
      {
        options.SignInScheme =
          CookieAuthenticationDefaults.AuthenticationScheme;
        // Authority here is the URL for the IdentityProvider project
        options.Authority = "https://localhost:5011";
        options.ClientId = "BlazorAuto";
        options.ClientSecret = "u2u-secret"; // Store in a safe place!

        // When set to code, the middleware will use PKCE protection
        options.ResponseType = OpenIdConnectResponseType.Code;
        options.Scope.Add(OpenIdConnectScope.OpenIdProfile);
        options.Scope.Add(OpenIdConnectScope.OpenId);
        options.Scope.Add("country");
        options.ClaimActions.MapUniqueJsonKey("country", "country");

        options.Scope.Add("u2uApi");

        // It's recommended to always get claims from the 
        // UserInfoEndpoint during the flow. 
        options.GetClaimsFromUserInfoEndpoint = true;

        options.SignedOutRedirectUri = "/";
      }
    );

    // builder.Services.ConfigureCookieOidcRefresh(CookieAuthenticationDefaults.AuthenticationScheme, MS_OIDC_SCHEME);

    builder.Services.AddAuthorization(options =>
    {
      options.AddPolicy(Policies.FromBelgium, Policies.FromBelgiumAuthorizationPolicy());
    });
    builder.Services.AddCascadingAuthenticationState();
    builder.Services.AddScoped<AuthenticationStateProvider, PersistingAuthenticationStateProvider>();
    builder.Services.AddHttpContextAccessor();

    // ConfigureCookieOidcRefresh attaches a cookie OnValidatePrincipal callback to get
    // a new access token when the current one expires, and reissue a cookie with the
    // new access token saved inside. If the refresh fails, the user will be signed
    // out. OIDC connect options are set for saving tokens and the offline access
    // scope.
    builder.Services.ConfigureCookieOidcRefresh(CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);

    // This will provide the access_token
    builder.Services.AddAccessTokenManagement();
    
    builder.Services.AddHttpClient<ExternalWeatherService>(
      client =>
      {
        // change to localhost.fiddler to see traffic in fiddler
        client.BaseAddress = new Uri("https://localhost:5005");
      });

    // Services for Weather component when running server side
    builder.Services.AddScoped<IWeatherService, WeatherService>();
    builder.Services.AddScoped<IExternalWeatherService, ExternalWeatherService>();


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

    app.MapGet("/forecasts-internal",
      async ValueTask<IEnumerable<WeatherForecast>> (IWeatherService weatherService) =>
    {
      return await weatherService.GetForecastsAsync();
    })
    .RequireAuthorization(Policies.FromBelgium);

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode()
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(BlazorApp.Auto.WithOpenIdConnect.Client._Imports).Assembly);

    app.MapGet("forecasts-forwarder", async ([FromServices] ExternalWeatherService weatherService) =>
    {
      return await weatherService.GetForecastsAsync();
    })
    .RequireAuthorization(Policies.FromBelgium);


    app.MapGroup("/authentication").MapLoginAndLogout();

    app.Run();
  }
}