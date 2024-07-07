using Microsoft.Extensions.Logging;

namespace BlazorApp.Testing.Tests;
internal class LoggerMock : ILogger
{
  public List<(LogLevel logLevel, object? state)> Journal { get; set; }
    = []; // New C# array syntax

  public IDisposable? BeginScope<TState>(TState state)
  => throw new NotImplementedException();

  public bool IsEnabled(LogLevel logLevel)
  => true;

  public void Log<TState>(LogLevel logLevel, EventId eventId,
    TState state, Exception? exception,
    Func<TState, Exception?, string> formatter) 
    => Journal.Add((logLevel, state));
}
