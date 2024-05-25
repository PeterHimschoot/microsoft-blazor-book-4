namespace BlazorApp.PizzaPlace.Shared;

public interface IOrderService
{
  ValueTask PlaceOrder(Customer customer, ShoppingBasket basket);
}
