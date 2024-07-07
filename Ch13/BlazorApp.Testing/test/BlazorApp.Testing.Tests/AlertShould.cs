using BlazorApp.Testing.Components;
using BlazorApp.Testing.Components.Pages;
using Bunit;

namespace BlazorApp.Testing.Tests;

public class AlertShould : TestContext
{
  [Fact]
  public void RenderSimpleChildContent()
  {
    IRenderedComponent<Alert> cut =
    RenderComponent<Alert>(parameters =>
      parameters.AddChildContent("<p>Hello world!</p>"));
    cut.MarkupMatches(
    """
    <div class="alert alert-secondary mt-4" role="alert">
      <p>Hello world!</p>
    </div>
    """);
  }

  [Fact]
  public void RenderCounterAsChildContent()
  {
    IRenderedComponent<Alert> cut =
      RenderComponent<Alert>(parameters =>
      parameters.AddChildContent<Counter>()
    );
    cut.Find("p")
       .MarkupMatches("""<p role="status">Current count: 0</p>""");
  }

  [Fact]
  public void RenderTwoWayCounterWithParametersAsChildContent()
  {
    IRenderedComponent<Alert> cut =
    RenderComponent<Alert>(parameters =>
      parameters.AddChildContent<TwoWayCounter>(parameters =>
        parameters.Add(counter => counter.CurrentCount, 3))
    );
    cut.Find("p")
       .MarkupMatches("""<p role="status">Current count: 3</p>""");
  }

  [Fact]
  public void RenderTitleAndCounterAsChildContent()
  {
    const string header = "<h1>This is a counter</h1>";
    IRenderedComponent<Alert> cut =
    RenderComponent<Alert>(parameters =>
      parameters.AddChildContent(header)
                .AddChildContent<Counter>());
    AngleSharp.Dom.IElement h1 = cut.Find("h1");
    h1.MarkupMatches(header);
    AngleSharp.Dom.IElement p = cut.Find("p");
    p.MarkupMatches("""<p role="status">Current count: 0</p>""");
  }

  [Fact]
  public void RenderCorrectly()
  {
    IRenderedComponent<Alert> cut = 
    RenderComponent<Alert>(parameters =>
      parameters.AddChildContent("<p>Hello world!</p>"));
    cut.MarkupMatches(
    """
    <div class="alert alert-secondary mt-4" role="alert">
              <p diff:ignore></p>
    </div>
    """);
  }
}
