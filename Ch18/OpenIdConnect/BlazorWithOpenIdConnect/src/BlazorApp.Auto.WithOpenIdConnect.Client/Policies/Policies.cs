using Microsoft.AspNetCore.Authorization;

namespace BlazorApp.Auto.WithOpenIdConnect.Client.Policies;

public static class Policies
{
  public const string FromBelgium = "FromBelgium";

  public static AuthorizationPolicy FromBelgiumAuthorizationPolicy()
      => new AuthorizationPolicyBuilder()
      .RequireAuthenticatedUser()
      .RequireClaim("country", "BE")
      .Build();
}
