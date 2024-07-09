using System.Drawing;

namespace BlazorApp.SignalR.Client;

public struct LineSegment
{
  //public LineSegment(PointF start, PointF end)
  //{
  //  Start = start;
  //  End = end;
  //}

  public required PointF Start { get; set; }

  public required PointF End { get; set; }
}