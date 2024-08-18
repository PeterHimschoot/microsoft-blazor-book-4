using System.Security.Claims;

namespace BlazorApp.Auto.WithOpenIdConnect.Client;

// Add properties to this class and update the server and client AuthenticationStateProviders
// to expose more information about the authenticated user to the client.
public sealed class UserInfo
{
  public required string UserId { get; init; }
  public required string Name { get; init; }
  public required string GivenName { get; init; }
  public required string Country { get; init; }

  public const string UserIdClaimType = "sid";
  public const string NameClaimType = "name";
  public const string GivenNameClaimType = "given_name";
  public const string CountryClaimType = "country";

  public static UserInfo FromClaimsPrincipal(ClaimsPrincipal principal) =>
    new()
    {
      UserId = GetRequiredClaim(principal, UserIdClaimType),
      Name = GetRequiredClaim(principal, NameClaimType),
      GivenName = GetRequiredClaim(principal, GivenNameClaimType),
      Country = GetRequiredClaim(principal, CountryClaimType)
    };

  public ClaimsPrincipal ToClaimsPrincipal() =>
    new(new ClaimsIdentity(
      [
        new(UserIdClaimType, UserId), 
        new(NameClaimType, Name),
        new(GivenNameClaimType, GivenName),
        new(CountryClaimType, Country),
      ],
      authenticationType: nameof(UserInfo),
      nameType: NameClaimType,
      roleType: null));

  private static string GetRequiredClaim(ClaimsPrincipal principal, string claimType) =>
    principal.FindFirst(claimType)?.Value 
    ?? throw new InvalidOperationException($"Could not find required '{claimType}' claim.");
}
