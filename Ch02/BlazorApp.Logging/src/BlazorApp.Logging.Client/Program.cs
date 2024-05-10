using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

// Enable this to get all logging messages
#if DEBUG
builder.Logging.SetMinimumLevel(LogLevel.Trace);
#endif

WebAssemblyHost host = builder.Build();

ILogger<Program> logger = host.Services
                 .GetRequiredService<ILoggerFactory>()
                 .CreateLogger<Program>();

logger.LogInformation("Logged after the app is built in the Program file.");

await host.RunAsync();
