using System.Net.Http.Json;

namespace BlazorApp.StateManagement.WASM.Client.Services;

public class StateService
{
  private readonly HttpClient _httpClient;

  public StateService(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task<int> GetValue(string key)
  {
    return await _httpClient.GetFromJsonAsync<int>($"/state/{key}");
  }

  public async Task SetValue(string key, int value)
  {
    await _httpClient.PutAsJsonAsync(requestUri: $"/state/{key}", value);
  }
}
