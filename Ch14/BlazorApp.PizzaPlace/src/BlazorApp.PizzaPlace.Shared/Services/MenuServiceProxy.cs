
using System.Net.Http.Json;

namespace BlazorApp.PizzaPlace.Shared.Services;

public class MenuServiceProxy : IMenuService
{
  private readonly IHttpClientFactory _httpClientFactory;

  public MenuServiceProxy(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async ValueTask<Pizza[]> GetMenu()
  {
    using HttpClient _httpClient = _httpClientFactory.CreateClient(nameof(MenuServiceProxy));

    return await _httpClient.GetFromJsonAsync<Pizza[]>("pizzas") ?? [];
  }
}
