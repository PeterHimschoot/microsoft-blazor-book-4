using IdentityProvider;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();

    builder.Services
      .AddIdentityServer(options =>
      {
        // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
        options.EmitStaticAudienceClaim = true;
      })
      .AddInMemoryIdentityResources(Config.GetIdentityResources())
      .AddTestUsers(Config.GetUsers())
      .AddInMemoryClients(Config.GetClients())
      .AddDeveloperSigningCredential()
    ;

    var app = builder.Build();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseIdentityServer();
    app.UseAuthorization();
    app.MapRazorPages().RequireAuthorization();

    app.Run();
  }
}