using Microsoft.JSInterop;

namespace BlazorApp.JavaScriptInterop.Services;

public class LocalStorageWithModule : ILocalStorage, IAsyncDisposable
{
  private readonly Lazy<Task<IJSObjectReference>> moduleTask;

  public LocalStorageWithModule(IJSRuntime jsRuntime)
  {
    moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
      "import", "./scripts/localstorage.js").AsTask());

  }

  public async ValueTask<T> GetProperty<T>(string propName)
  {
    IJSObjectReference module = await moduleTask.Value;
    return await module.InvokeAsync<T>("get", propName);
  }

  public async ValueTask SetProperty<T>(string propName, T value)
  {
    IJSObjectReference module = await moduleTask.Value;
    await module.InvokeVoidAsync("set", propName, value);
  }

  public async ValueTask WatchAsync<T>(T instance) where T : class
  {
    IJSObjectReference module = await moduleTask.Value;
    await module.InvokeVoidAsync("watch",
      DotNetObjectReference.Create(instance));
  }

  public async ValueTask DisposeAsync() {
    if (moduleTask.IsValueCreated)
    {
      IJSObjectReference module = await moduleTask.Value;
      await module.DisposeAsync();
    }
  }
}
