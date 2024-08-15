using BlazorApp.Server.WithOpenIdConnect.Components;
using BlazorApp.Server.WithOpenIdConnect.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

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
        options.Authority = "https://localhost:5011";
        options.ClientId = "BlazorServer";
        options.ClientSecret = "u2u-secret";
    
        // When set to code, the middleware will use PKCE protection
        options.ResponseType = "code id_token";
    
        // It's recommended to always get claims from the 
        // UserInfoEndpoint during the flow. 
        options.GetClaimsFromUserInfoEndpoint = true;
        options.Scope.Add("country");
        options.ClaimActions.MapUniqueJsonKey("country", "country");

        options.Scope.Add("roles");
        options.ClaimActions.MapUniqueJsonKey("role", "role");
        options.TokenValidationParameters = new()
        {
          RoleClaimType = "role"
        };

        // Save the tokens we receive from the IDP
        options.SaveTokens = true;

        options.Scope.Add("u2uApi");
      });

    builder.Services.AddCascadingAuthenticationState();

    builder.Services.AddAccessTokenManagement();
    builder.Services.AddUserAccessTokenHttpClient(nameof(WeatherService), null,
      client =>
      {
        client.BaseAddress = new Uri("https://localhost:5005");
      });
      builder.Services.AddScoped<WeatherService>();

    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();

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
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();

    app.MapGroup("/authentication").MapLoginAndLogout();

    app.Run();
  }
}