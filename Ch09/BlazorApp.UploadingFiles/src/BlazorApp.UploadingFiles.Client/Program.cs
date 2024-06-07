using BlazorApp.UploadingFiles.Client;
using BlazorApp.UploadingFiles.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add this line
builder.Services.AddSingleton<IUploadService, WASMUploadService>();

await builder.Build().RunAsync();
