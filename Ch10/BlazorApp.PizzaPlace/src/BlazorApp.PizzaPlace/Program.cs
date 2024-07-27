using BlazorApp.PizzaPlace.Components;
using BlazorApp.PizzaPlace.Shared;
using BlazorApp.PizzaPlace.Shared.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
       .AddTransient<IMenuService, HardCodedMenuService>()
       .AddTransient<IOrderService, ConsoleOrderService>();

// *** Add this line ***
builder.Services.AddScoped<State>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  _ = app.UseExceptionHandler("/Error", createScopeForErrors: true);
  _ = app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
