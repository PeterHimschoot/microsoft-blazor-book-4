using BlazorApp.SignalR.Client;
using Microsoft.AspNetCore.SignalR;

namespace BlazorApp.SignalR.Hubs;

public class BoardHub : Hub
{
  private static readonly List<LineSegment> allSegments = [];
  private readonly ILogger<BoardHub> _logger;

  public BoardHub(ILogger<BoardHub> logger)
  => this._logger = logger;

  public async Task GetAllSegments()
  {
    _logger.LogInformation(
      $"{nameof(GetAllSegments)} - {allSegments.Count}");
    await Clients.Caller.SendAsync("InitSegments", allSegments);
  }

  public async Task SendSegments(IEnumerable<LineSegment> segments)
  {
    _logger.LogInformation(nameof(SendSegments));
    allSegments.AddRange(segments);
    await Clients.Others.SendAsync("AddSegments", segments);
  }
}
