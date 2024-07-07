using BlazorApp.Testing.Components.Pages;
using Bunit;
using FluentAssertions;

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
       .MarkupMatches(@"<p role=""status"">Current count: 1</p>");
  }

  [Theory]
  [InlineData(3)]
  [InlineData(-3)]
  public void IncrementCounterWithIncrementWhenClicked(int increment)
  {
    IRenderedComponent<TwoWayCounter> cut =
    RenderComponent<TwoWayCounter>(
      ("CurrentCount", 0),
      ("Increment", increment)
    );
    cut.Find("button")
       .Click();
    cut.Find("p")
       .MarkupMatches(@$"<p role=""status"">Current count: {increment}</p>");
  }

  [Theory]
  [InlineData(3)]
  [InlineData(-3)]
  public void IncrementCounterWithIncrementWhenClickedWithNameOf(int increment)
  {
    IRenderedComponent<TwoWayCounter> cut =
    RenderComponent<TwoWayCounter>(
      (nameof(TwoWayCounter.CurrentCount), 0),
      (nameof(TwoWayCounter.Increment), increment)
    );
    cut.Find("button")
       .Click();
    cut.Find("p")
       .MarkupMatches(@$"<p role=""status"">Current count: {increment}</p>");
  }

  [Fact]
  public async Task TriggerChangedEventForCurrentCounter()
  {
    int nrOfCurrentCountChanged = 0;
    int nrOfIncrementChanged = 0;
    IRenderedComponent<TwoWayCounter> cut = RenderComponent<TwoWayCounter>(parameters =>
    parameters.Add(counter => counter.CurrentCount, 0)
              .Add(counter => counter.Increment, 1)
              .Add(counter => counter.CurrentCountChanged,
              () => nrOfCurrentCountChanged++)
              .Add(counter => counter.IncrementChanged,
              () => nrOfIncrementChanged++)
    );

    cut.Find("button").Click();
    await cut.Instance.SetIncrement(2);
    _ = nrOfCurrentCountChanged.Should().Be(1);
    _ = nrOfIncrementChanged.Should().Be(1);
  }

  [Fact]
  public void TriggerChangedEventForCurrentCounter2()
  {
    IRenderedComponent<TwoWayCounter> cut = 
    RenderComponent<TwoWayCounter>(parameters =>
      parameters.Add(counter => counter.CurrentCount, 0)
    );
    cut.SetParametersAndRender(parameters =>
      parameters.Add(counter => counter.CurrentCount, 2));
    cut.Find("p")
       .MarkupMatches(@$"<p role=""status"">Current count: 2</p>");
  }
}
