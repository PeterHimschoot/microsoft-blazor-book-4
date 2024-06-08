using BlazorApp.QuickGridDemo.Entities;

namespace BlazorApp.QuickGridDemo.Services;

public class EmployeeService
{
  private readonly IHttpClientFactory _clientFactory;
  private readonly ILogger<EmployeeService> _logger;

  public EmployeeService(IHttpClientFactory clientFactory, ILogger<EmployeeService> logger)
  {
    _clientFactory = clientFactory;
    _logger = logger;
  }

  public async Task<IEnumerable<Employee>> GetEmployees(int? results, int? page = null)
  {
    HttpClient httpClient = _clientFactory.CreateClient(nameof(EmployeeService));

    string queryString = "?seed=u2u";
    if (results.HasValue)
    {
      queryString = $"{queryString}&results={results.Value}";
    }
    if (page.HasValue)
    {
      queryString = $"{queryString}&page={page.Value}";
    }
    RandomUserResult? result =
      await httpClient.GetFromJsonAsync<RandomUserResult>(queryString);
    return result!.Results;
  }
}
