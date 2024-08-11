using BlazorApp.Server.WithOpenIdConnect.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

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
      });

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

    app.Run();
  }
}