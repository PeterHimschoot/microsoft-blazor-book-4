namespace BlazorApp.PizzaPlace.Shared.Services;

public class ConsoleOrderService : IOrderService
{
  public ValueTask PlaceOrder(Customer customer, ShoppingBasket basket)
  {
    Console.WriteLine($"Placing order for {customer.Name}");
    return new ValueTask();
  }
}
