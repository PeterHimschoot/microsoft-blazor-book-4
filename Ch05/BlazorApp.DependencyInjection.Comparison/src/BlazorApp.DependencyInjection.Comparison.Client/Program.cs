using BlazorApp.DependencyInjection.Comparison.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

_ = builder.Services
           .AddSingleton<ISingletonService, WASMSingletonService>()
           .AddTransient<ITransientService, WASMTransientService>()
           .AddScoped<IScopedService, WASMScopedService>();

_ = builder.Services
           .AddKeyedSingleton<IGreeter, FrenchGreeter>(serviceKey: "French")
           .AddKeyedSingleton<IGreeter, EnglishGreeter>(serviceKey: "English");

await builder.Build().RunAsync();
