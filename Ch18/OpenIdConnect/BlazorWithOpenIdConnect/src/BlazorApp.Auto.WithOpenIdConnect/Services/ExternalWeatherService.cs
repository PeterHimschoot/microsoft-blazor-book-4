using BlazorApp.Auto.WithOpenIdConnect.Client.Entities;
using BlazorApp.Auto.WithOpenIdConnect.Client.Services;
using Microsoft.AspNetCore.Authentication;

namespace BlazorApp.Auto.WithOpenIdConnect.Services;

public class ExternalWeatherService : IExternalWeatherService
{
  private readonly HttpClient _httpClient;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public ExternalWeatherService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
  {
    _httpClient = httpClient;
    _httpContextAccessor = httpContextAccessor;
  }

  public async ValueTask<IEnumerable<WeatherForecast>> GetForecastsAsync()
  {
    HttpContext? httpContext =
      _httpContextAccessor.HttpContext
      ?? throw new InvalidOperationException("No HttpContext available");
    string accessToken =
      await httpContext.GetTokenAsync("access_token")
      ?? throw new InvalidOperationException("No access_token was saved.");

    _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", accessToken);

    return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("/WeatherForecast") ?? [];
  }
}