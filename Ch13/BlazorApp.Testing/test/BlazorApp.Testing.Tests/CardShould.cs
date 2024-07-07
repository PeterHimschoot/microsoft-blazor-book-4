using BlazorApp.Testing.Components;
using Bunit;
using System.Text.RegularExpressions;

namespace BlazorApp.Testing.Tests;
public class CardShould : TestContext
{
  [Fact]
  public void RenderCorrectlyWithProperId()
  {
    IRenderedComponent<Card> cut = 
      RenderComponent<Card>();
    cut.MarkupMatches(
    """
    <h3 diff:ignorecase diff:regex id:regex="card-\d{1,4}">
      card \d{1,4}
    </h3>
    """);
  }
}