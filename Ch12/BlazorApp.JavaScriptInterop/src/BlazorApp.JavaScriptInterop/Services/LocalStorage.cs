using Microsoft.JSInterop;

namespace BlazorApp.JavaScriptInterop.Services;

public class LocalStorage : ILocalStorage
{
  private readonly IJSRuntime _jsRuntime;

  public LocalStorage(IJSRuntime js) => _jsRuntime = js;

  public ValueTask<T> GetProperty<T>(string propName)
  => _jsRuntime.InvokeAsync<T>("blazorLocalStorage.get", propName);

  public ValueTask SetProperty<T>(string propName, T value)
  => _jsRuntime.InvokeVoidAsync("blazorLocalStorage.set", propName, value);

  public ValueTask WatchAsync<T>(T instance) where T : class
  => _jsRuntime.InvokeVoidAsync("blazorLocalStorage.watch",
    DotNetObjectReference.Create(instance));
}
