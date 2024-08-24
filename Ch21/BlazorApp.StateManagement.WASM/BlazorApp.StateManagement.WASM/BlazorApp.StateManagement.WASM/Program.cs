using BlazorApp.StateManagement.WASM.Client.Pages;
using BlazorApp.StateManagement.WASM.Components;
using BlazorApp.StateManagement.WASM.Entities;
using Microsoft.AspNetCore.Mvc;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveWebAssemblyComponents();

    builder.Services.AddScoped<State>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseWebAssemblyDebugging();
    }
    else
    {
      app.UseExceptionHandler("/Error", createScopeForErrors: true);
      // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(BlazorApp.StateManagement.WASM.Client._Imports).Assembly);

    app.MapGet("/state/{key}", (string key, State state) =>
    {
      return state[key]; 
    });

    app.MapPut("/state/{key}", (string key, State state, [FromBody] int value) =>
    {
      state[key] = value;
    });

    app.Run();
  }
}