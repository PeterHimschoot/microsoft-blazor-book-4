namespace BlazorApp.DataBinding;

public class Member
{
  public required string Name { get; set; }

  public required string Email { get; set; }

  public required string Password { get; set; }

  public string Message { get; set; } = string.Empty;

  public required string Country { get; set; } 

  public bool Subscriber { get; set; }

  public Gender Gender { get;set; }
}
