namespace BlazorApp.PizzaPlace.Shared;
public class State
{
  public Pizza[] Pizzas { get; set; } = [];
  public ShoppingBasket Basket { get; } = new();
  public decimal TotalPrice
  => Basket.Orders.Sum(id => GetPizza(id)!.Price);
  public Pizza? GetPizza(int id)
  => Pizzas.SingleOrDefault(pizza => pizza.Id == id);
}