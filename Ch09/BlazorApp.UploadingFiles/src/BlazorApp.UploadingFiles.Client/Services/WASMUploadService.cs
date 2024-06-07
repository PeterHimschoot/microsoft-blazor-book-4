using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.UploadingFiles.Client.Services;

public class WASMUploadService : IUploadService
{
  private const int maxAllowedFiles = 10;
  private const int maxFileSize = 10_000_000;
  private readonly ILogger<WASMUploadService> _logger;

  public WASMUploadService(ILogger<WASMUploadService> logger)
  {
    _logger = logger;
  }

  public ValueTask<List<IBrowserFile>> LoadFilesAsync(InputFileChangeEventArgs e)
  {
    List<IBrowserFile> loadedFiles = [];
    foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
    {
      try
      {
        loadedFiles.Add(file);
      }
      catch (Exception ex)
      {
        _logger.LogError("File: {FileName} Error: {Error}",
            file.Name, ex.Message);
      }
    }
    return ValueTask.FromResult(loadedFiles);
  }
}
