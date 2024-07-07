using BlazorApp.Testing.Components.Pages;
using Bunit;

namespace BlazorApp.Testing.Tests;
public class CounterWithVCShould : TestContext
{
  [Fact]
  public void ShouldUseCascadingIncrement()
  {
    IRenderedComponent<CounterWithCV> cut = 
    RenderComponent<CounterWithCV>(parameters =>
      parameters.AddCascadingValue(name: "Increment", cascadingValue: 3));
    cut.Find(cssSelector: "button")
       .Click();
    cut.Find(cssSelector: "p")
       .MarkupMatches("""<p role="status">Current count: 3</p>""");
  }
}
