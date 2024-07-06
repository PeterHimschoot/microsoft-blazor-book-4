namespace BlazorApp.JavaScriptInterop.Services;

public interface ILocalStorage
{
  ValueTask<T> GetProperty<T>(string propName);
  ValueTask SetProperty<T>(string propName, T value);
  ValueTask WatchAsync<T>(T instance) where T : class;
}
