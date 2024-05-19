using Microsoft.AspNetCore.Components.Forms;
using System.Text.RegularExpressions;

namespace BlazorApp.UsingForms.Components;

public partial class MemberCustomValidator : CustomValidator<Member>
{
  public const string EmailRegExPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

  [GeneratedRegex(EmailRegExPattern)]
  public static partial Regex EmailRegEx();

  protected override IEnumerable<string> Fields { get; } =
    [nameof(Member.Name), nameof(Member.Email)];

  protected override Action<Member, ValidationMessageStore> GetFieldValidator(string field)
  {
    return field switch
    {
      nameof(Member.Name) => ValidateName,
      nameof(Member.Email) => ValidateEmail,
      _ => (_, __) => { }
    };
  }

  private void ValidateName(Member member, ValidationMessageStore store)
  {
    if (member.Name is not { Length: > 0 })
    {
      store?.Add(() => member.Name, "Name is mandatory");
    }
    else if (member.Name is not { Length: < 100 })
    {
      store?.Add(() => member.Name, "Name cannot be longer that 100 characters");
    }
  }

  private void ValidateEmail(Member member, ValidationMessageStore store)
  {
    if (member.Email is not { Length: > 0 })
    {
      store?.Add(() => member.Email, "Email is mandatory");
    }
    else
    if (!EmailRegEx().IsMatch(member.Email))
    {
      store?.Add(() => member.Email, "This is not a valid e-mail address");
    }
  }
}
