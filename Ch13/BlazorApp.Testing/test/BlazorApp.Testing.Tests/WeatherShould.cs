using BlazorApp.Testing.Components.Pages;
using BlazorApp.Testing.Entities;
using BlazorApp.Testing.Services;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace BlazorApp.Testing.Tests;
public class WeatherShould : TestContext
{
  [Fact]
  public void UseWeatherService()
  {
    const int nrOfForecasts = 5;

    WeatherServiceStub stub = new()
    {
      FakeForecasts = Enumerable.Repeat(new WeatherForecast(), nrOfForecasts)
                                .ToArray()
    };
    _ = Services.AddSingleton<IWeatherService>(stub);
    LoggerMock logger = new();
    _ = Services.AddSingleton<ILogger>(logger);
    IRenderedComponent<Weather> cut = RenderComponent<Weather>();
    IRefreshableElementCollection<AngleSharp.Dom.IElement> rows =
      cut.FindAll("tbody tr");
    _ = rows.Count.Should().Be(nrOfForecasts);
  }

  [Fact]
  public void UseProperLogging()
  {
    const int nrOfForecasts = 5;
    WeatherServiceStub stub = new()
    {
      FakeForecasts = Enumerable.Repeat(new WeatherForecast(), nrOfForecasts)
                                .ToArray()
    };
    _ = Services.AddSingleton<IWeatherService>(stub);

    LoggerMock logger = new();
    _ = Services.AddSingleton<ILogger>(logger);
    _ = RenderComponent<Weather>();
    _ = logger.Journal.Count.Should().Be(1);
    _ = logger.Journal.First().state.Should().NotBeNull();
    _ = logger.Journal.First().state!.ToString().Should().Contain("Fetching forecasts");
  }

  [Fact]
  public void UseWeatherServiceWithNSubstitute()
  {
    const int nrOfForecasts = 5;

    WeatherForecast[]? fakeForecasts =
      Enumerable.Repeat(new WeatherForecast(), nrOfForecasts)
                .ToArray();

    IWeatherService stub = Substitute.For<IWeatherService>();
    stub.GetForecasts().Returns(fakeForecasts);
    _ = Services.AddSingleton<IWeatherService>(stub);
    ILogger logger = Substitute.For<ILogger>();
    _ = Services.AddSingleton<ILogger>(logger);
    IRenderedComponent<Weather> cut = RenderComponent<Weather>();
    IRefreshableElementCollection<AngleSharp.Dom.IElement> rows =
      cut.FindAll("tbody tr");
    _ = rows.Count.Should().Be(nrOfForecasts);
  }

  [Fact]
  public void UseProperLoggingWithNSubstitute()
  {
    const int nrOfForecasts = 5;
    WeatherServiceStub stub = new()
    {
      FakeForecasts = Enumerable.Repeat(new WeatherForecast(), nrOfForecasts)
                                .ToArray()
    };
    _ = Services.AddSingleton<IWeatherService>(stub);
    // Create an ILogger mock
    ILogger logger = Substitute.For<ILogger>();
    _ = Services.AddSingleton<ILogger>(logger);
    _ = RenderComponent<Weather>();
    // Did the Log method get called?
    logger.Received().Log(LogLevel.Information, message: "Fetching forecasts");
    // logger.Received().Log(LogLevel.Information, message: Arg.Any<string>());
  }
}
