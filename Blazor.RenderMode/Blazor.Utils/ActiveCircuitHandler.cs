using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Utils;
public class ActiveCircuitHandler(ActiveCircuitState state) : CircuitHandler
{
  public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
  {
    state.CircuitExists = true;
    return base.OnCircuitOpenedAsync(circuit, cancellationToken);
  }

  public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
  {
    state.CircuitExists = false;
    return base.OnCircuitClosedAsync(circuit, cancellationToken);
  }
}
