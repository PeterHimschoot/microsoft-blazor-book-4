namespace BlazorApp.PizzaPlace.Shared;

public class Order
{
  public required Customer Customer { get; set; }
  public required ShoppingBasket Basket { get; set; }
}
