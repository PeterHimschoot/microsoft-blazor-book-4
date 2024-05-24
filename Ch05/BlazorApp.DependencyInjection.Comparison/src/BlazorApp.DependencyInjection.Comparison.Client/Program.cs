using BlazorApp.DependencyInjection.Comparison.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

_ = builder.Services
           .AddSingleton<ISingletonService, WASMSingletonService>()
           .AddTransient<ITransientService, WASMTransientService>()
           .AddScoped<IScopedService, WASMScopedService>();

await builder.Build().RunAsync();
