using BlazorApp.CascadingParameters.Components;
using BlazorApp.CascadingParameters.State;
using Microsoft.AspNetCore.Components;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add a root-level cascading value
builder.Services.AddCascadingValue(
  _ => new UserInfo { UserName = "Jefke" });

// Add a root-level named cascading value
builder.Services.AddCascadingValue("Named",
  _ => new UserInfo { UserName = "Peter" });

// Add a root-level non-fixed cascading value
builder.Services.AddCascadingValue("Fixed",
_ =>
{
  UserInfo ui = new() { UserName = "Peter" };
  CascadingValueSource<UserInfo> source = new(ui, isFixed: false);
  return source;
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  _ = app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  _ = app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
