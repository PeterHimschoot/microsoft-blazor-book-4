using BlazorApp.Testing.Components.Pages;
using Bunit;

namespace BlazorApp.Testing.Tests;
public class TwoWayCounterShould : TestContext
{
  [Fact]
  public void IncrementCounterWhenClicked()
  {
    IRenderedComponent<TwoWayCounter> cut = 
      RenderComponent<TwoWayCounter>(
        parameters => parameters
          .Add(counter => counter.CurrentCount, 0)
          .Add(counter => counter.Increment, 1)
        );
    cut.Find("button")
       .Click();
    cut.Find("p")
       .MarkupMatches("<p>Current count: 1</p>");
  }
}
