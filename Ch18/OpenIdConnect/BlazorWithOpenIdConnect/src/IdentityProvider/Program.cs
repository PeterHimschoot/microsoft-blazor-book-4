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
        options.EmitStaticAudienceClaim = true;
      })
      .AddInMemoryIdentityResources(Config.GetIdentityResources())
      .AddTestUsers(Config.GetUsers())
      .AddInMemoryClients(Config.GetClients())
      .AddDeveloperSigningCredential()
      .AddInMemoryApiScopes(Config.GetApiScopes())
      .AddInMemoryApiResources(Config.GetApiResources())
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