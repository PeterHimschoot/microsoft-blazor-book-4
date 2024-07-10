using BlazorApp.UsinggRPC.Client.Entities;
using BlazorApp.UsinggRPC.Protos;
using Grpc.Net.Client;

namespace BlazorApp.UsinggRPC.Client.Services;

public class ForecastGrpcService : IWeatherService
{
  private readonly GrpcChannel grpcChannel;

  public ForecastGrpcService(GrpcChannel grpcChannel)
  => this.grpcChannel = grpcChannel;

  public async ValueTask<WeatherForecast[]> GetForecasts()
  {
    var client =
      new protoWeatherForecasts.protoWeatherForecastsClient(this.grpcChannel);
    var request = new getForecastsRequest();
    getForecastsResponse? response =
      await client.getForecastsAsync(request);
    return response.Forecasts.Select(f =>
      new WeatherForecast
    {
      Date = DateOnly.FromDateTime(f.Date.ToDateTime()),
      TemperatureC = f.TemperatureC,
      Summary = f.Summary,
      Image = f.Image.ToByteArray()
    }).ToArray();
  }
}
