using System.Net.Http.Json;

namespace BlazorApp.PizzaPlace.Shared.Services;

public class OrderMenuProxy : IOrderService
{
  private readonly IHttpClientFactory _httpClientFactory;

  public OrderMenuProxy(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async ValueTask PlaceOrder(Customer customer, ShoppingBasket basket)
  {
    Order order = new()
    {
      Customer = customer,
      Basket = basket
    };
    HttpClient httpClient = _httpClientFactory.CreateClient(nameof(OrderMenuProxy));
    await httpClient.PostAsJsonAsync("order", order);
  }
}
