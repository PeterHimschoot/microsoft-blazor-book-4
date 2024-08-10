namespace BlazorApp.PizzaPlace.Shared;
public class State
{
  public Pizza[] Pizzas { get; set; } = [];
  public ShoppingBasket Basket { get; } = new();

  public Customer Customer { get; set; } = new()
  {
    Id = 0,
    Name = string.Empty,
    Street = string.Empty,
    City = string.Empty,
    ZipCode = string.Empty
  };

  public decimal TotalPrice
  => Basket.Orders.Sum(id => GetPizza(id)!.Price);

  public Pizza? GetPizza(int id)
  => Pizzas.SingleOrDefault(pizza => pizza.Id == id);

  // *** Add this line **
  //public Pizza? CurrentPizza { get; set; }
}