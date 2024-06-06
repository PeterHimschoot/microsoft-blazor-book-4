namespace BlazorApp.PizzaPlace.Shared;
public class Customer
{
  public int Id { get; set; }

  public required string Name { get; set; }

  public required string Street { get; set; }

  public required string City { get; set; }

  public required string ZipCode { get; set; }
}
