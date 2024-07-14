using BlazorApp.UsinggRPC.Protos;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;
using Grpc.Core;

namespace BlazorApp.UsinggRPC.Services;

public class WeatherForecastProtoService 
  : protoWeatherForecasts.protoWeatherForecastsBase
{
  private readonly ImageService imageService;

  public WeatherForecastProtoService(ImageService imageService)
  => this.imageService = imageService;

  private static readonly string[] Summaries = new[]
  {
    "Freezing", "Cool", "Warm", "Hot", "Sweltering", "Scorching"
  };

  public override Task<getForecastsResponse> getForecasts(
    getForecastsRequest request, 
    ServerCallContext context)
  {
    IEnumerable<weatherForecast>? forecasts =
    Enumerable.Range(1, 250).Select(index => new weatherForecast
    {
      Date = Timestamp.FromDateTime(
        DateTime.UtcNow.AddDays(index)),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = Summaries[Random.Shared.Next(Summaries.Length)],
      Image = ByteString.CopyFrom(this.imageService.RandomImage())
    });
    var response = new getForecastsResponse();
    response.Forecasts.AddRange(forecasts);
    return Task.FromResult(response);
  }
}
