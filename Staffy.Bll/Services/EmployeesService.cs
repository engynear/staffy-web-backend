using Staffy.Bll.Models;
using Staffy.Bll.Services.Interfaces;
using Staffy.Dal.Entitites;
using Staffy.Dal.Repositories.Interfaces;

namespace Staffy.Bll.Services;

public class EmployeesService : IEmployeesService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        var employees = await _employeeRepository.GetAll();
        return employees.Select(e => new Employee
        {
            Id = e.Id,
            Name = e.Name,
            AvatarUrl = e.AvatarUrl
        });
    }

    public async Task<Employee?> GetEmployeeByIdAsync(long id)
    {
        var employee = await _employeeRepository.GetById(id);
        return employee == null ? null : new Employee
        {
            Id = employee.Id,
            Name = employee.Name,
        };
    }

    public async Task<long> AddEmployeeAsync(Employee employee)
    {
        var employeeEntity = new EmployeeEntity
        {
            Name = employee.Name,
            AvatarUrl = employee.AvatarUrl
        };
        return await _employeeRepository.Create(employeeEntity);
    }

    public async Task<Employee?> UpdateEmployeeAsync(long id, Employee employee)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteEmployeeAsync(long id)
    {
        await _employeeRepository.Delete(id);
    }
}