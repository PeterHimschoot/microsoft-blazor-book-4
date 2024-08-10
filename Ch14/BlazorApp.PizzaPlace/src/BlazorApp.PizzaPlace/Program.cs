using BlazorApp.PizzaPlace.Components;
using BlazorApp.PizzaPlace.Shared;
using BlazorApp.PizzaPlace.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services
       .AddTransient<IMenuService, HardCodedMenuService>()
       .AddTransient<IOrderService, ConsoleOrderService>();

builder.Services.AddScoped<State>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseWebAssemblyDebugging();
}
else
{
  _ = app.UseExceptionHandler("/Error", createScopeForErrors: true);
  _ = app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode()
   .AddInteractiveWebAssemblyRenderMode()
   .AddAdditionalAssemblies(typeof(Pizza).Assembly);

app.MapGet("/pizzas", async Task<Pizza[]> (IMenuService menuService) =>
{
  return await menuService.GetMenu();
});

app.MapPost("/order", async ValueTask (IOrderService orderService, [FromBody] Order order) =>
{
  await orderService.PlaceOrder(order.Customer, order.Basket);
});

app.Run();
