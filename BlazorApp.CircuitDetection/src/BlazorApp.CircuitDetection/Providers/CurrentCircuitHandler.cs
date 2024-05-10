using Microsoft.AspNetCore.Components.Server.Circuits;

namespace BlazorApp.CircuitDetection.Providers;

public class CurrentCircuitHandler : CircuitHandler
{
  public Circuit? Current { get; set; }

  public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
  {
    Current = circuit;
    return base.OnCircuitOpenedAsync(circuit, cancellationToken);
  }

  public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
  {
    Current = null;
    return base.OnCircuitClosedAsync(circuit, cancellationToken);
  }
}
