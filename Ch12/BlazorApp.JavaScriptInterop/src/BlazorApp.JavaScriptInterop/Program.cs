using BlazorApp.JavaScriptInterop.Components;
using BlazorApp.JavaScriptInterop.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
  .AddRazorComponents()
  .AddInteractiveServerComponents();

// Register LocalStorage Service
//builder.Services
//  .AddScoped<ILocalStorage, LocalStorage>();
builder.Services
  .AddScoped<ILocalStorage, LocalStorageWithModule>();

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
