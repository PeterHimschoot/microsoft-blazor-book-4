namespace BlazorApp.LifeCycle.Services;

public interface IDepartmentService
{
  IEnumerable<string> GetEmployees(int departmentId);

  ValueTask<IEnumerable<string>> GetEmployeesAsync(int departmentId);
}
