using Microsoft.AspNetCore.Components.Server.Circuits;

namespace BlazorApp.CircuitDetection.Providers;

public class LoggingCircuitHandler : CircuitHandler
{
  private readonly ILogger<LoggingCircuitHandler> _logger;

  public int Count { get; set; } = 0;

  public LoggingCircuitHandler(ILogger<LoggingCircuitHandler> logger)=> _logger = logger;

  public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
  {
    Count += 1;
    _logger.LogInformation("Circuit {circuitId} was {curcuitStatus}", circuit.Id, "Opened");
    return base.OnCircuitOpenedAsync(circuit, cancellationToken);
  }

  public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
  {
    Count -= 1;
    _logger.LogInformation("Circuit {circuitId} was {curcuitStatus}", circuit.Id, "Closed");
    return base.OnCircuitClosedAsync(circuit, cancellationToken);
  }

  public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Circuit {circuitId} was {curcuitStatus}", circuit.Id, "ConnectionDown");
    return base.OnConnectionDownAsync(circuit, cancellationToken);
  }

  public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Circuit {circuitId} was {curcuitStatus}", circuit.Id, "ConnectionUp");
    return base.OnConnectionDownAsync(circuit, cancellationToken);
  }
}
