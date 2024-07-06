using BlazorApp.Testing.Components;
using Bunit;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp.Testing.Tests;
public class MouseTrackerShould : TestContext
{
  [Fact]
  public void ShowCorrectMousePosition()
  {
    MouseEventArgs eventArgs = new()
    {
      ClientX = 100,
      ClientY = 200
    };
    IRenderedComponent<MouseTracker> cut = RenderComponent<MouseTracker>();
    AngleSharp.Dom.IElement theDiv = cut.Find(cssSelector: "div");
    theDiv.MouseMove(eventArgs);
    theDiv.MarkupMatches(
      $"<div style:ignore>Mouse at {eventArgs.ClientX}x{eventArgs.ClientY}"
    );
  }
}
