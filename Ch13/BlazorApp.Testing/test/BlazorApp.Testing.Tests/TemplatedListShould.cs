using BlazorApp.Testing.Components;
using Bunit;
using FluentAssertions;

namespace BlazorApp.Testing.Tests;
public class TemplatedListShould : TestContext
{
  [Fact]
  public void RenderLoadingTemplateWhenItemsIsNull()
  {
    const string loading =
    "<div class=\"loader\">Loading...</div>";

    static ValueTask<IEnumerable<string>?> loader()
    => new(result: null);

    IRenderedComponent<TemplatedList<string>> cut =
    RenderComponent<TemplatedList<string>>(parameters =>
      parameters.Add(tl => tl.Loader, loader)
                .Add(tl => tl.LoadingContent, loading)
    );
    cut.Find("div.loader")
       .MarkupMatches(loading);
  }

  [Fact]
  public void RenderItemsCorrectly()
  {
    const int count = 5;
    static ValueTask<IEnumerable<string>> loader()
      => new ValueTask<IEnumerable<string>>(
        Enumerable.Repeat("A", count)
      );
    IRenderedComponent<TemplatedList<string>> cut =
    RenderComponent<TemplatedList<string>>(parameters =>
      parameters.Add(tl => tl.Loader, loader)
                .Add(tl => tl.ItemContent,
                      (context) => $"<p>{context}</p>"));

    IRefreshableElementCollection<AngleSharp.Dom.IElement> ps = cut.FindAll("p");
    _ = ps.Should().NotBeEmpty();
    foreach (AngleSharp.Dom.IElement p in ps)
    {
      p.MarkupMatches("<p>A</p>");
    }
  }

  [Fact]
  public void RenderItemsWithListItemCorrectly()
  {
    const int count = 5;
    static ValueTask<IEnumerable<string>> loader()
      => new ValueTask<IEnumerable<string>>(
        Enumerable.Repeat("A", count)
      );
    IRenderedComponent<TemplatedList<string>> cut =
    RenderComponent<TemplatedList<string>>(parameters =>
      parameters.Add(tl => tl.Loader, loader)
                .Add<ListItem, string>(tl => tl.ItemContent,
                      (context) => itemParams => itemParams.Add(p => p.Item, context)
                      ));

    IRefreshableElementCollection<AngleSharp.Dom.IElement> ps = cut.FindAll("p");
    _ = ps.Should().NotBeEmpty();
    foreach (AngleSharp.Dom.IElement p in ps)
    {
      p.MarkupMatches("<p>A</p>");
    }
  }
}