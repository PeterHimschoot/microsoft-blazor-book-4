using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using IdentityModel;
using System.Security.Claims;

namespace IdentityProvider;

public class Config
{
  public static List<TestUser> GetUsers()
  => [
    new TestUser
    {
      SubjectId = "{223C9865-03BE-4951-8911-740A438FCF9D}",
      Username = "peter@u2u.be",
      Password = "u2u-secret",
      Claims =
      [
        new Claim("given_name", "Peter"),
        new Claim(JwtClaimTypes.Name, "Peter Himschoot"),
        new Claim("family_name", "Himschoot"),
        new Claim("country", "BE"),
        new Claim("role","admin")
      ]
    },
    new TestUser
    {
      SubjectId = "{34119795-78A6-44C2-B128-30BFBC29139D}",
      Username = "student@u2u.be",
      Password = "u2u-secret",
      Claims =
      [
        new Claim("given_name", "Student"),
        new Claim(JwtClaimTypes.Name, "Student Blazor"),
        new Claim("family_name", "Blazor"),
        new Claim("country", "UK"),
        new Claim("role","tester")
      ]
    }
  ];

  public static IEnumerable<IdentityResource> GetIdentityResources()
  => [
    new IdentityResources.OpenId(),
    new IdentityResources.Profile(),
    new IdentityResource(name: "country",
      displayName: "User country",
      userClaims: [ "country" ]),
    new IdentityResource(name: "roles",
      displayName: "User role(s)",
      userClaims: [ "role" ]),
  ];

  public static IEnumerable<Client> GetClients()
  => [
    new Client
    {
      ClientName = "Blazor Server",
      ClientId = "BlazorServer",
      AllowedGrantTypes = GrantTypes.Hybrid,
      RedirectUris = ["https://localhost:5002/signin-oidc"],
      PostLogoutRedirectUris = [ "https://localhost:5002/" ],
      RequirePkce = false,
      AllowedScopes = {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        "country",
        "roles",
        "u2uApi"
      },
      ClientSecrets = { new Secret("u2u-secret".Sha512()) },
      RequireConsent = true
    },
    new Client {
      ClientName = "BlazorWasm",
      ClientId = "BlazorWasm",
      AllowedGrantTypes = GrantTypes.Code,
      RequirePkce = true,
      RequireClientSecret = false,
      RedirectUris = [
        "https://localhost:5003/authentication/login-callback"
      ],
      PostLogoutRedirectUris = [
        "https://localhost:5003/authentication/logout-callback"
      ],
      AllowedCorsOrigins = {
        "https://localhost:5003"
      },
      AllowedScopes = {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        "u2uApi",
        "roles",
        "country"
      }
      // RequireConsent = true
    },
    new Client
    {
      ClientName = "Blazor Auto",
      ClientId = "BlazorAuto",
      AllowedGrantTypes = GrantTypes.Code,
      RedirectUris = [
        "https://localhost:5001/signin-oidc"
      ],
      LogoUri = "https://www.u2u.be/images/U2U_logo.svg",
      PostLogoutRedirectUris = [ "https://localhost:5001/" ],
      RequirePkce = false,
      AllowedScopes = {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        IdentityServerConstants.StandardScopes.OfflineAccess,
        "country",
        "u2uApi",
      },
      ClientSecrets = { new Secret("u2u-secret".Sha512()) },
      RequireConsent = true,
      AllowOfflineAccess = true
    }
  ];

  public static IEnumerable<ApiScope> GetApiScopes()
  => [
    new ApiScope("u2uApi", "U2U API")
  ];

  public static IEnumerable<ApiResource> GetApiResources()
  => [
    new ApiResource("u2uApi", "U2U API")
    {
        Scopes = [ "u2uApi" ],
        UserClaims = [ "country" ]
    }
  ];
}
