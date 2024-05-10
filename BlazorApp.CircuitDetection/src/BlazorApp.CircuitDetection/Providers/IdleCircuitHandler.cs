
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.Options;
using Timer = System.Timers.Timer;

namespace BlazorApp.CircuitDetection.Providers;

public sealed class IdleCircuitHandler : CircuitHandler, IDisposable
{
  private Circuit? currentCircuit;
  private readonly ILogger logger;
  private readonly Timer timer;

  public IdleCircuitHandler(ILogger<IdleCircuitHandler> logger,
      IOptions<IdleCircuitOptions> options)
  {
    timer = new Timer
    {
      Interval = options.Value.IdleTimeout.TotalMilliseconds,
      AutoReset = false
    };

    timer.Elapsed += CircuitIdle;
    this.logger = logger;
  }

  private void CircuitIdle(object? sender, System.Timers.ElapsedEventArgs e)
  {
    logger.LogInformation("{CircuitId} is idle", currentCircuit?.Id);
  }

  public override Task OnCircuitOpenedAsync(Circuit circuit,
      CancellationToken cancellationToken)
  {
    currentCircuit = circuit;

    return Task.CompletedTask;
  }

  public override Func<CircuitInboundActivityContext, Task> CreateInboundActivityHandler(
      Func<CircuitInboundActivityContext, Task> next)
  {
    return context => // context contains a reference to the circuit
    {
      timer.Stop();
      timer.Start();
      return next(context);
    };
  }

  public void Dispose() => timer.Dispose();
}

public class IdleCircuitOptions
{
  public TimeSpan IdleTimeout { get; set; } = TimeSpan.FromMinutes(5);
}

public static class IdleCircuitHandlerServiceCollectionExtensions
{
  public static IServiceCollection AddIdleCircuitHandler(
      this IServiceCollection services,
      Action<IdleCircuitOptions> configureOptions)
  {
    services.Configure(configureOptions);
    services.AddIdleCircuitHandler();

    return services;
  }

  public static IServiceCollection AddIdleCircuitHandler(
      this IServiceCollection services)
  {
    services.AddScoped<CircuitHandler, IdleCircuitHandler>();

    return services;
  }
}