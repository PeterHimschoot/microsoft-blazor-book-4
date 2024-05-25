namespace BlazorApp.PizzaPlace.Shared;
public class ShoppingBasket
{
  public List<int> Orders { get; } = [];
  public void Add(int pizzaId)
  => Orders.Add(pizzaId);
  public void RemoveAt(int pos)
 => Orders.RemoveAt(pos);
}