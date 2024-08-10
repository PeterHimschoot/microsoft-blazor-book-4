using FluentValidation;
using System.Text.RegularExpressions;

namespace BlazorApp.PizzaPlace.Shared.Validation;

public partial class CustomerFluentValidator 
  : AbstractValidator<Customer>
{
  [GeneratedRegex("^[1-9]\\d{3}$", 
    RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)]
  public static partial Regex _zipcode();

  public CustomerFluentValidator()
  {
    _ = RuleFor(cust => cust.Name)
      .Must(name => name is { Length: > 0 })
      .WithMessage("Please provide a name");

    _ = RuleFor(cust => cust.Street)
      .Must(street => street is { Length: > 0 })
      .WithMessage("Please provide a street with house number.");

    _ = RuleFor(cust => cust.City)
      .Must(city => city is { Length: > 0 })
      .WithMessage("Please provide a city");

    _ = RuleFor(cust => cust.ZipCode)
      .Must(zipcode => zipcode is { Length: > 0 })
      .WithMessage("Please provide a zip code");

    _ = RuleFor(cust => cust.ZipCode)
      .Must(zipcode => _zipcode().IsMatch(zipcode))
      .WithMessage("Zipcode is between 1000 and 9999");
  }
}
