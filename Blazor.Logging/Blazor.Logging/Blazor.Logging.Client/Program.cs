using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

internal class Program
{
  private static async global::System.Threading.Tasks.Task Main(string[] args)
  {
    var builder = WebAssemblyHostBuilder.CreateDefault(args);

    // Enable this to get all logging messages
    #if DEBUG
    builder.Logging.SetMinimumLevel(LogLevel.Trace);
    #endif

    var host = builder.Build();

    var logger = host.Services
                     .GetRequiredService<ILoggerFactory>()
                     .CreateLogger<Program>();

    logger.LogInformation("Logged after the app is built in the Program file.");

    await host.RunAsync();
  }
}