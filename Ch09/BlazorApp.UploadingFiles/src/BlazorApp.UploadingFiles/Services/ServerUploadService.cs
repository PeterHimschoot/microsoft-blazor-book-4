using BlazorApp.UploadingFiles.Client;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.UploadingFiles.Services;

public class ServerUploadService : IUploadService
{
  private const int maxAllowedFiles = 10;
  private const int maxFileSize = 10_000_000;
  private readonly IWebHostEnvironment _environment;
  private readonly ILogger<ServerUploadService> _logger;

  public ServerUploadService(IWebHostEnvironment environment, 
    ILogger<ServerUploadService> logger)
  {
    _environment = environment;
    _logger = logger;
  }

  public async ValueTask<List<IBrowserFile>> 
    LoadFilesAsync(InputFileChangeEventArgs e)
  {
    List<IBrowserFile> loadedFiles = [];

    foreach (IBrowserFile file in e.GetMultipleFiles(maxAllowedFiles))
    {
      try
      {
        loadedFiles.Add(file);

        string trustedFileNameForFileStorage = Path.GetRandomFileName();
        string path = Path.Combine(_environment.ContentRootPath,
                _environment.EnvironmentName, "Uploads",
                trustedFileNameForFileStorage);

        await using FileStream fs = new(path, FileMode.Create);
        await file.OpenReadStream(maxFileSize).CopyToAsync(fs);
      }
      catch (Exception ex)
      {
        _logger.LogError("File: {Filename} Error: {Error}", file.Name, ex.Message);
      }
    }
    return loadedFiles;
  }


}
