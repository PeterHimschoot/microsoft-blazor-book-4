
//using System.ComponentModel.DataAnnotations;

namespace BlazorApp.SSR;

public class Member
{
  public const string EmailRegEx = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

  //[Required(ErrorMessage = "Name is mandatory")]
  //[StringLength(100, ErrorMessage = "Name cannot be longer that 100 characters")]
  public required string Name { get; set; }

  //[Required(ErrorMessage = "Email is mandatory")]
  //[RegularExpression(EmailRegEx, ErrorMessage = "This is not a valid e-mail address")]
  public required string Email { get; set; }

  //[Required(ErrorMessage = "Password is mandatory")]
  //[StringLength(maximumLength: 100, 
  //  MinimumLength = 14, 
  //  ErrorMessage = "Passwords should be at least 14 long, an no more that 100")]
  public required string Password { get; set; }

  public string Message { get; set; } = string.Empty;

  public required string Country { get; set; }

  public bool Subscriber { get; set; }

  public Gender Gender { get; set; }
}
