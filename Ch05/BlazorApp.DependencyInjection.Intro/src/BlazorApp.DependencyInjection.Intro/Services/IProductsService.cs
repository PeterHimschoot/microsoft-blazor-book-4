using BlazorApp.DependencyInjection.Intro.Entities;

namespace BlazorApp.DependencyInjection.Intro.Services;

public interface IProductsService
{
  IEnumerable<Product> GetProducts();
}
