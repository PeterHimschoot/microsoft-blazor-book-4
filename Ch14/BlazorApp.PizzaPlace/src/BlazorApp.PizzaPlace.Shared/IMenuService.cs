namespace BlazorApp.PizzaPlace.Shared;
public interface IMenuService
{
  ValueTask<Pizza[]> GetMenu();
}