namespace BlazorApp.PizzaPlace.Shared.Services;

public class HardCodedMenuService : IMenuService
{
  public ValueTask<Pizza[]> GetMenu()
  {
    Pizza[] pizzas = [
      new Pizza {
        Id = 1,
        Name = "Pepperoni",
        Price = 8.99M,
        Spiciness = Spiciness.Spicy
      },
      new Pizza {
        Id = 2,
        Name = "Margherita",
        Price = 7.99M,
        Spiciness = Spiciness.None 
      },
      new Pizza
      {
        Id = 3,
        Name = "Diavola",
        Price = 9.99M,
        Spiciness = Spiciness.Hot
      }
    ];
    return ValueTask.FromResult(pizzas);
  }
}
