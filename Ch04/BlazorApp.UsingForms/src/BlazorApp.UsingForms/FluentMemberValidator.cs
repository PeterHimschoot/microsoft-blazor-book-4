using FluentValidation;
using System.Text.RegularExpressions;

namespace BlazorApp.UsingForms;

public partial class FluentMemberValidator : AbstractValidator<Member>
{
  public const string EmailRegExPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

  [GeneratedRegex(EmailRegExPattern)]
  public static partial Regex EmailRegEx();

  public FluentMemberValidator()
  {
    _ = RuleFor(member => member.Name)
      .Must(name => name is string { Length: > 0 })
      .WithMessage("Name is mandatory")
      .Must(name => name is string { Length: < 100 })
      .WithMessage("Name cannot be longer that 100 characters");

    _ = RuleFor(member => member.Email)
      .Must(email => email is string { Length: > 0 })
      .WithMessage("Email is mandatory");

    _ = When(member => member.Email is { Length: > 0 }, () =>
    {
      _ = RuleFor(member => member.Email)
        .Must(email => EmailRegEx().IsMatch(email))
        .WithMessage("This is not a valid e-mail address");
    });
  }
}
