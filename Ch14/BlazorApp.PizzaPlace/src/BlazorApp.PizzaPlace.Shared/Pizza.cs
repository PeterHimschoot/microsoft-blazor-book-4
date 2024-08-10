namespace BlazorApp.PizzaPlace.Shared;
public class Pizza
{
  public required int Id { get; init; }
  public required string Name { get; init; }
  public required decimal Price { get; init; }
  public required Spiciness Spiciness { get; init; }
}
