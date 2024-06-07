using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.UploadingFiles.Client;
public interface IUploadService
{
  ValueTask<List<IBrowserFile>> LoadFilesAsync(InputFileChangeEventArgs e);
}
