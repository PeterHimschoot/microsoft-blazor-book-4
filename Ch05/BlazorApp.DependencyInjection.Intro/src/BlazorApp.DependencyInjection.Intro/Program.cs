using BlazorApp.DependencyInjection.Intro.Components;
using BlazorApp.DependencyInjection.Intro.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
       .AddSingleton<IProductsService, HardCodedProductsService>();

//HardCodedProductsService hardCodedProductsService = new();
//builder.Services
//       .AddSingleton<IProductsService>(hardCodedProductsService);

//builder.Services
//       .AddTransient<IProductsService, HardCodedProductsService>();

builder.Services
       .AddScoped<IProductsService, HardCodedProductsService>();



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
