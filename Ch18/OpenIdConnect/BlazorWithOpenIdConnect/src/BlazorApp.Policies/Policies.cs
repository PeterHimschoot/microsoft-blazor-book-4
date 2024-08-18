using Microsoft.AspNetCore.Authorization;

namespace BlazorApp.Policies;

public class Policies
{
  public const string FromBelgium = "FromBelgium";

  public static AuthorizationPolicy FromBelgiumPolicy()
    => new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .RequireClaim("country", "BE")
    .Build();
}
