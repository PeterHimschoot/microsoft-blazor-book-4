using BlazorApp.DependencyInjection.Comparison.Client.Pages;
using BlazorApp.DependencyInjection.Comparison.Client.Services;
using BlazorApp.DependencyInjection.Comparison.Components;
using BlazorApp.DependencyInjection.Comparison.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

_ = builder.Services
           .AddSingleton<ISingletonService, SRSingletonService>()
           .AddTransient<ITransientService, SRTransientService>()
           .AddScoped<IScopedService, SRScopedService>();


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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp.DependencyInjection.Comparison.Client._Imports).Assembly);

app.Run();
