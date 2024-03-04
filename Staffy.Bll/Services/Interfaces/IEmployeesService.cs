using Staffy.Bll.Models;

namespace Staffy.Bll.Services.Interfaces;

public interface IEmployeesService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(long id);
    Task<long> AddEmployeeAsync(Employee employee);
    Task<Employee?> UpdateEmployeeAsync(long id, Employee employee);
    Task DeleteEmployeeAsync(long id);
}